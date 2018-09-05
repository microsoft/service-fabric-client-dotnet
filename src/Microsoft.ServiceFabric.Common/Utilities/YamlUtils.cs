// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Utility and extension methods for YAML/JSON operations.
    /// </summary>
    public static class YamlUtils
    { 
        /// <summary>
        /// Returns the Value of a key in a JSON file
        /// </summary>
        /// <param name="jsonFilePath">the path of the json</param>
        /// <param name="key">key in the json file</param>
        /// <returns>Value of the Key in the json</returns>
        public static string GetKeyValueFromJSON(string jsonFilePath, string key)
        {
            using (StreamReader file = File.OpenText(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                while (reader.Read())
                {
                    if (reader.Value != null && (string.Compare(reader.TokenType.ToString(), key, StringComparison.OrdinalIgnoreCase) == 0))
                    {
                       return reader.Value.ToString();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Takes in a comma separated list of yamls and generates a list of merged json descritions
        /// </summary>
        /// <param name="yamlInputFiles">Yaml files to merged as comma separated list</param>
        /// <param name="outputRootDirectory">Output directory for the merged resource descriptions</param>
        /// <returns>list of paths of merged files</returns>
        public static IList<string> GenerateMergedResourceDescription(string yamlInputFiles, string outputRootDirectory)
        {
            var yamlFilesList = yamlInputFiles.Split(',');
            var outputFolder = string.Format("{0}\\{1}", outputRootDirectory, Guid.NewGuid().ToString());

            // TODO give input to merge tool all the yamlfile list and output folder and type:SF_SBZ_JSON
            // return list of all json list
            var returnedJSONFileListFromMerge = new List<string>();

            return returnedJSONFileListFromMerge;
        }
    }
}
