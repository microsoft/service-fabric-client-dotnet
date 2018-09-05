// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using SfSbzYamlMergeUtils;

    /// <summary>
    /// Utility and extension methods for YAML/JSON operations.
    /// </summary>
    internal static class YamlUtils
    {
        internal enum ResourseType
        {
            VOLUME,
            NETWORK,
            APPLICATION,
            GATEWAY,
            UNKNOWN,
        }

        internal static List<Tuple<ResourseType, string, string, string>> GetFinalResourceDescriptionFromYamls(List<string> yamlInputFileList, string outputRootDirectory)
        {
            GenerateMergedResourceDescription(yamlInputFileList, outputRootDirectory);

            // Get allfiles SortedbyName from the folder
            var generatedFilesList = Directory.GetFiles(outputRootDirectory, "*.json", SearchOption.AllDirectories).Select(fn => new FileInfo(fn)).OrderBy(f => f.Name);

            var resourceDescriptionList = new List<Tuple<ResourseType, string, string, string>>();
            foreach (var fileIter in generatedFilesList)
            {
                // generate a list of tuple<name, type, description string>
                // call get resource description from file
                resourceDescriptionList.Add(GetResourceDescriptionFromFile(fileIter.FullName));
            }

            return resourceDescriptionList;
        }

        /// <summary>
        /// Returns the Resource description from a JSON file
        /// </summary>
        /// <param name="jsonFilePath">the path of the json</param>
        /// <returns>Resource description</returns>
        internal static Tuple<ResourseType, string, string, string> GetResourceDescriptionFromFile(string jsonFilePath)
        {
            ResourseType rtype = ResourseType.UNKNOWN;
            string rName = null, rDesc = null, rapiVersion = null;

            // TODO Serialize with a json definition obj ??
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                dynamic tempArray = JsonConvert.DeserializeObject(json);
                foreach (var item in tempArray)
                {
                    if (item != null && (rName == null || rDesc == null || rapiVersion == null))
                    {
                        if (item.Value != null && (string.Compare(item.Name.ToString(), "type", StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            rtype = (ResourseType)Enum.Parse(typeof(ResourseType), item.Value.ToString().ToUpper());
                        }
                        else if (item.Value != null && (string.Compare(item.Name.ToString(), "name", StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            rName = item.Value.ToString();
                        }
                        else if (item.Value != null && (string.Compare(item.Name.ToString(), "description", StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            rDesc = item.Value.ToString();
                        }
                        else if (item.Value != null && (string.Compare(item.Name.ToString(), "api-version", StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            rapiVersion = item.Value.ToString();
                        }
                    }
                }
            }

            return (new Tuple<ResourseType, string, string, string>(rtype, rName, rDesc, rapiVersion));
        }

        /// <summary>
        /// Takes in a comma separated list of yamls and generates a list of merged json descritionss
        /// </summary>
        /// <param name="yamlInputFileList">Yaml files to merged as comma separated list</param>
        /// <param name="outputRootDirectory">Output directory for the merged resource descriptions</param>
        internal static void GenerateMergedResourceDescription(List<string> yamlInputFileList, string outputRootDirectory)
        {
            // Give input to merge tool all the yamlfile list and output folder and of type:SF_SBZ_JSON
            SfSbzYamlMergeLib.GenerateMergedDescriptions(yamlInputFileList.ToArray(), outputRootDirectory, OutputType.SF_SBZ_JSON);
        }
    }
}
