using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SharpObfuscator.Obfuscation2
{
	public delegate void ObfuscatorOutputEvent(StreamReader standardOutput, StreamReader standardError);
	public delegate string ObfuscatorRequestReferencedAssemblyPath(string typeToLoad, string initialAssemblyPath);
	public delegate void ObfuscatorNameObfuscated(ObfuscationItem item, string initialName, string obfuscatedName, string notes);
	public delegate void ObfuscatorProgress(string phaseName, int percents);

	sealed public class Obfuscator
	{

		#region Variables

		private Dictionary<string, bool> _assembliesPaths = new Dictionary<string, bool>();
		private List<string> _excludedTypesNames = new List<string>();
		private string _outputDirectory = "";

		private bool _obfuscateTypes;
		private bool _obfuscateMethods;
		private bool _obfuscateNamespaces;
        private bool _obfuscateProperties;
        private bool _obfuscateFields;

		//----
		private XmlDocument _xmlMapping;
		private XmlElement _xmlMappingRoot;

		//----
		private long _obfuscatedMethodId = -1;
		private long _obfuscatedTypeId = -1;
		private long _obfuscatedNamespaceId = -1;
        private long _obfuscatedPropertyId = -1;
        private long _obfuscatedFieldId = -1;

		private Dictionary<string, string> _resourcesMapping = new Dictionary<string, string>();

		private List<AssemblyDefinition> assembliesDefinitions = new List<AssemblyDefinition>();

		private Dictionary<string, string> _obfuscatedNamespaces = new Dictionary<string, string>();

		//---- Events
		public event ObfuscatorOutputEvent OutputEvent;
		public event ObfuscatorRequestReferencedAssemblyPath RequestReferencedAssemblyPath;
		public event ObfuscatorNameObfuscated NameObfuscated;
		public event ObfuscatorProgress Progress;

		#endregion

		#region Constructor

        public Obfuscator(string outputDirectory, bool obfuscateTypes, bool obfuscateMethods, 
            bool obfuscateNamespaces, bool obfuscateProperties, bool obfuscateMembers)
		{
			_outputDirectory = outputDirectory;
			_obfuscateTypes = obfuscateTypes;
			_obfuscateMethods = obfuscateMethods;
			_obfuscateNamespaces = obfuscateNamespaces;
            _obfuscateProperties = obfuscateProperties;
            _obfuscateFields = obfuscateMembers;
		}

		#endregion

		#region AddAssembly

		public void AddAssembly(string path, bool obfuscate)
		{
			_assembliesPaths.Add(path, obfuscate);
		}

		#endregion

		#region ExcludeType

		public void ExcludeType(string typeName)
		{
			_excludedTypesNames.Add(typeName);
		}

		#endregion

		#region SetProgress

		private void SetProgress(string message, int percent)
		{
			if (Progress != null)
				Progress(message, percent);
		}

		#endregion

		#region StartObfuscation

		public void StartObfuscation()
		{
			Thread thread = new Thread(new ThreadStart(AsyncStartObfuscation));
			thread.Start();
		}

		private void AsyncStartObfuscation()
		{
			List<string> assembliesPaths = new List<string>();
			List<bool> assembliesToObfuscate = new List<bool>();

			SetProgress("Loading...", 0);

			//---- Create the Xml Document for mapping
			_xmlMapping = new XmlDocument();
			_xmlMappingRoot = _xmlMapping.CreateElement("mappings");
			_xmlMapping.AppendChild(_xmlMappingRoot);

			//---- Load the assemblies
			foreach (string assemblyPath in _assembliesPaths.Keys)
			{
				// Full load the assembly
				AssemblyDefinition assembly = AssemblyFactory.GetAssembly(assemblyPath);
				foreach (ModuleDefinition module in assembly.Modules)
					module.FullLoad();

				assembliesDefinitions.Add(assembly);
				assembliesPaths.Add(Path.GetFileName(assemblyPath));
				assembliesToObfuscate.Add(_assembliesPaths[assemblyPath]);
			}

			SetProgress("Obfuscate...", 0);

			//---- Obfuscate the assemblies
			int assemblyIndex = -1;
			foreach (AssemblyDefinition assembly in assembliesDefinitions)
			{
				assemblyIndex++;

				if (!assembliesToObfuscate[assemblyIndex])
					continue;

				SetProgress("Obfuscate assembly: " + assembly.Name.Name, 0);

				//---- Obfuscate Types / Methods
				foreach (TypeDefinition type in assembly.MainModule.Types)
					ObfuscateType(type);

				//---- Obfuscate Namespaces
				if (_obfuscateNamespaces)
					foreach (TypeDefinition type in assembly.MainModule.Types)
						ObfuscateNamespace(type);

				//---- Obfuscate Resources
				foreach (Resource resource in assembly.MainModule.Resources)
					ObfuscateResource(resource);

				SetProgress("Obfuscate resource: " + assembly.Name.Name, 100);
			}

			SetProgress("Saving...", 0);

			//---- Save the modified assemblies
			assemblyIndex = -1;
			foreach (AssemblyDefinition assembly in assembliesDefinitions)
			{
				assemblyIndex++;

                //---- Create output directory if it doesn't exists
                if (Directory.Exists(_outputDirectory) == false)
                    Directory.CreateDirectory(_outputDirectory);

				//---- Delete previous file
				string outputFileName = Path.Combine(_outputDirectory, "Obfuscated." + assembliesPaths[assemblyIndex]);
				if (File.Exists(outputFileName))
					File.Delete(outputFileName);

				//---- Save the modified assembly
				AssemblyFactory.SaveAssembly(assembly, outputFileName);
			}

			//---- Save mapping
			_xmlMapping.Save(Path.Combine(_outputDirectory, "Mapping.xml"));

			SetProgress("Complete.", 100);
		}

		#endregion

		#region ObfuscateResource

		private void ObfuscateResource(Resource resource)
		{
			string resourceName = resource.Name.Substring(0, resource.Name.Length - 10);

			if (!_resourcesMapping.ContainsKey(resourceName))
				return;

			string obfucatedName = _resourcesMapping[resourceName];
			resource.Name = obfucatedName + ".resources";
		}

		#endregion

		#region ObfuscateNamespace

		private void ObfuscateNamespace(TypeDefinition type)
		{
			/*
						if (type.Name == "<Module>")
							return;

						if (type.IsRuntimeSpecialName)
							return;

						if (type.IsSpecialName)
							return;

						if (type.Name.Contains("Resources"))
							return;

						if (type.Name.StartsWith("<")) // Like "<PrivateImplementationDetails>"
							return;

						if (type.Name.Contains("__"))
							return;
			*/
			if (type.Namespace.Length < 1)
				return;

			if (_excludedTypesNames.Contains(type.FullName))
				return;

			//---- Obfuscate
			string initialFullName = type.FullName;
			string initialNamespace = type.Namespace;
			type.Namespace = GetObfuscatedNamespace(type.Namespace);

			//---- Update the type references in other assemblies
			foreach (AssemblyDefinition assembly in assembliesDefinitions)
				foreach (ModuleDefinition module in assembly.Modules)
					foreach (TypeReference typeReference in module.TypeReferences)
						if (typeReference.Namespace == initialNamespace)
							typeReference.Namespace = type.Namespace;

			//---- Resources
			Dictionary<string, string> newDictionary = new Dictionary<string, string>();
			foreach (string key in _resourcesMapping.Keys)
			{
				string resValue = _resourcesMapping[key];
				if (resValue.Contains("."))
					if (resValue.Substring(0, resValue.LastIndexOf('.')) == initialNamespace)
						resValue = type.Namespace + resValue.Substring(resValue.LastIndexOf('.'));

				newDictionary.Add(key, resValue);
			}

			_resourcesMapping = newDictionary;
		}

		private string GetObfuscatedNamespace(string initialNamespace)
		{
			if (_obfuscatedNamespaces.ContainsKey(initialNamespace))
				return _obfuscatedNamespaces[initialNamespace];

			string[] namespaceSet = initialNamespace.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
			string currentNs = "";
			string currentNsObfuscated = "";
			foreach (string ns in namespaceSet)
			{
				if (currentNs.Length > 0)
				{
					currentNs += ".";
					currentNsObfuscated += ".";
				}

				currentNs += ns;

				if (!_obfuscatedNamespaces.ContainsKey(currentNs))
				{
					_obfuscatedNamespaces.Add(currentNs, currentNsObfuscated + ObfuscateString(ObfuscationItem.Namespace, ns, ""));
				}

				currentNsObfuscated = _obfuscatedNamespaces[currentNs];
			}

			return _obfuscatedNamespaces[initialNamespace];
		}

		#endregion

		#region ObfuscateType

		private void ObfuscateType(TypeDefinition type)
		{
			if (type.Name == "<Module>")
				return;

			if (type.IsRuntimeSpecialName)
				return;

			if (type.IsSpecialName)
				return;

			if (type.Name.Contains("Resources"))
				return;

			if (type.Name.StartsWith("<")) // Like "<PrivateImplementationDetails>"
				return;

			if (type.Name.Contains("__"))
				return;

			if (_excludedTypesNames.Contains(type.FullName))
				return;

			//---- Obfuscate
			string initialTypeName = type.FullName;
			type.Name = ObfuscateString(ObfuscationItem.Type, type.Name, "");

			//---- Prepare ressources names
			if (!initialTypeName.Contains("/"))
			{
				// Save the obfuscation mapping
				_resourcesMapping.Add(initialTypeName, type.FullName);
			}

			//---- Update the type references in other assemblies
			foreach (AssemblyDefinition assembly in assembliesDefinitions)
				foreach (ModuleDefinition module in assembly.Modules)
					foreach (TypeReference typeReference in module.TypeReferences)
						if (typeReference.FullName == initialTypeName)
							typeReference.Name = type.Name;

			//---- Obfuscate methods
			foreach (MethodDefinition method in type.Methods)
				ObfuscateMethod(type, initialTypeName, method);

            //---- Obfuscate properties
            foreach (PropertyDefinition property in type.Properties)
                ObfuscateProperty(type, property);

            //---- Obfuscate fields
            foreach (FieldDefinition field in type.Fields)
                ObfuscateField(type, field);
		}

		#endregion

		#region ObfuscateMethod

		private void ObfuscateMethod(TypeDefinition type, string initialTypeName, MethodDefinition method)
		{
			if (method.IsConstructor)
				return;

			if (method.IsRuntime)
				return;

			if (method.IsRuntimeSpecialName)
				return;

			if (method.IsSpecialName)
				return;

			if (method.IsVirtual)
				return;

			if (method.IsAbstract)
				return;

			if (method.Overrides.Count > 0)
				return;

			if (method.Name.StartsWith("<"))
				return;

			string initialName = method.Name;
			string obfuscatedName = ObfuscateString(ObfuscationItem.Method, method.Name, "");

			//---- Update the type references in other assemblies
			foreach (MethodReference reference in MethodReference.AllReferences)
			{
				if (reference.DeclaringType.Name == type.Name &&
					reference.DeclaringType.Namespace == type.Namespace)
					if (!Object.ReferenceEquals(reference, method) &&
						reference.Name == initialName &&
						reference.HasThis == method.HasThis &&
						reference.CallingConvention == method.CallingConvention &&
						reference.Parameters.Count == method.Parameters.Count &&
						reference.GenericParameters.Count == method.GenericParameters.Count &&
						reference.ReturnType.ReturnType.Name == method.ReturnType.ReturnType.Name &&
						reference.ReturnType.ReturnType.Namespace == method.ReturnType.ReturnType.Namespace
						)
					{
						bool paramsEquals = true;
						for (int paramIndex = 0; paramIndex < method.Parameters.Count; paramIndex++)
							if (reference.Parameters[paramIndex].ParameterType.FullName != method.Parameters[paramIndex].ParameterType.FullName)
							{
								paramsEquals = false;
								break;
							}

						for (int paramIndex = 0; paramIndex < method.GenericParameters.Count; paramIndex++)
							if (reference.GenericParameters[paramIndex].FullName != method.GenericParameters[paramIndex].FullName)
							{
								paramsEquals = false;
								break;
							}

						try
						{
							if (paramsEquals)
								reference.Name = obfuscatedName;
						}
						catch (InvalidOperationException) { }
					}

			}

			method.Name = obfuscatedName;
		}

		#endregion

        #region ObfuscateProperty

        /// <summary>
        /// TODO:
        /// * Skip special properties: indexers, > < etc..
        /// </summary>
        /// <param name="type"></param>
        /// <param name="initialTypeName"></param>
        /// <param name="property"></param>
        private void ObfuscateProperty(TypeDefinition type, PropertyDefinition property)
        {
            if (property.IsSpecialName)
                return;

            if (property.IsRuntimeSpecialName)
                return;

            string initialName = property.Name;
            string obfuscatedName = ObfuscateString(ObfuscationItem.Property, property.Name, "");

            //---- Update the type references in other assemblies
            foreach (MethodReference reference in MethodReference.AllReferences)
            {
                if (reference.DeclaringType.Name == type.Name &&
                    reference.DeclaringType.Namespace == type.Namespace)
                {
                    if (!Object.ReferenceEquals(reference, property) &&
                        (reference.Name == property.Name) &&
                        (reference.Parameters.Count == property.Parameters.Count) 
                        )
                    {
                        bool paramsEquals = true;
                        for (int paramIndex = 0; paramIndex < property.Parameters.Count; paramIndex++)
                            if (reference.Parameters[paramIndex].ParameterType.FullName != property.Parameters[paramIndex].ParameterType.FullName)
                            {
                                paramsEquals = false;
                                break;
                            }

                        try
                        {
                            if (paramsEquals)
                                reference.Name = obfuscatedName;
                        }
                        catch (InvalidOperationException) { }
                    }
                }
            }

            property.Name = obfuscatedName;
        }

        #endregion

        #region ObfuscateFields

        private void ObfuscateField(TypeDefinition type, FieldDefinition field)
        {
            if (field.IsRuntimeSpecialName)
                return;

            if (field.IsSpecialName)
                return;

            if (field.Name.StartsWith("<"))
                return;

            string initialName = field.Name;
            string obfuscatedName = ObfuscateString(ObfuscationItem.Field, field.Name, "");

            //---- Update the type references in other assemblies
            foreach (MethodReference reference in MethodReference.AllReferences)
            {
                if (reference.DeclaringType.Name == type.Name &&
                    reference.DeclaringType.Namespace == type.Namespace)
                    if (!Object.ReferenceEquals(reference, field) &&
                        (reference.Name == initialName)
                        )
                    {
                        try
                        {
                            reference.Name = obfuscatedName;
                        }
                        catch (InvalidOperationException) { }
                    }

            }

            field.Name = obfuscatedName;
        }

        #endregion

        #region ObfuscateString

        internal string ObfuscateString(ObfuscationItem item, string initialName, string notes)
		{
			string obfuscated = null;

			switch (item)
			{
				case ObfuscationItem.Method:
					if (!_obfuscateMethods)
						return initialName;
					_obfuscatedMethodId++;
					obfuscated = "M" + _obfuscatedMethodId;
					break;

				case ObfuscationItem.Type:
					if (!_obfuscateTypes)
						return initialName;
					_obfuscatedTypeId++;
					obfuscated = "T" + _obfuscatedTypeId;
					break;

				case ObfuscationItem.Namespace:
					_obfuscatedNamespaceId++;
					obfuscated = "N" + _obfuscatedNamespaceId;
					break;

                case ObfuscationItem.Property:
                    if (!_obfuscateProperties)
                        return initialName;
                    _obfuscatedPropertyId++;
                    obfuscated = "P" + _obfuscatedPropertyId;
                    break;

                case ObfuscationItem.Field:
                    if (!_obfuscateFields)
                        return initialName;
                    _obfuscatedFieldId++;
                    obfuscated = "F" + _obfuscatedFieldId;
                    break;
			}

			if (NameObfuscated != null)
				NameObfuscated(item, initialName, obfuscated, notes);

			// Xml mapping document
			XmlElement mappingElement = _xmlMapping.CreateElement("mapping");
			_xmlMappingRoot.AppendChild(mappingElement);
			mappingElement.SetAttribute("Type", item.ToString());
			mappingElement.SetAttribute("InitialValue", initialName);
			mappingElement.SetAttribute("ObfuscatedValue", obfuscated);

			return obfuscated;
		}

		#endregion

	}

	#region ObfuscationItem

	public enum ObfuscationItem
	{
		Namespace,
		Type,
		Method,
        Property,
        Field
	}

	#endregion

}