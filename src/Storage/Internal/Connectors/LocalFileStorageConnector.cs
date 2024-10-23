using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;

namespace EssentialToolkit.Storage
{
    public class LocalFileStorageConnector : AStorageConnector
    {
        private const string BASE_FILE_NAME = "UET-data-file_";

        #region Utils

        private string GetFilePath() => Path.Combine(Application.dataPath, BASE_FILE_NAME + GetSlot() + ".json");
        private string ReadFromFile(string key)
        {
            // Get the path to the file in the current Unity game directory
            var filePath = GetFilePath();

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // If the file doesn't exist, create a new JSON file with an empty object
                var emptyJson = new JObject();
                File.WriteAllText(filePath, emptyJson.ToString());
            }

            // Read the content of the file
            var jsonContent = File.ReadAllText(filePath);

            // Parse the JSON content
            var jsonObject = JObject.Parse(jsonContent);

            // Check if the key exists in the JSON object
            if (jsonObject.TryGetValue(key, out JToken value))
            {
                // Return the value associated with the key as a string
                return value.ToString();
            }
            else return null;
        }

        private void WriteToFile(string key, string value)
        {
            // Get the path to the file in the current Unity game directory
            string filePath = GetFilePath();

            // Check if the file exists
            JObject jsonObject;
            if (File.Exists(filePath))
            {
                // Read the existing file content
                var jsonContent = File.ReadAllText(filePath);
                jsonObject = JObject.Parse(jsonContent);
            }
            else
            {
                // If the file doesn't exist, create a new JSON object
                jsonObject = new JObject();
            }

            // Add or update the key-value pair
            jsonObject[key] = value;

            // Write the updated JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString());
        }

        private void DeleteKeyFromFile(string key)
        {
            // Get the path to the file in the current Unity game directory
            string filePath = GetFilePath();

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // If the file doesn't exist, nothing to delete
                Debug.LogWarning("File does not exist.");
                return;
            }

            // Read the existing file content
            var jsonContent = File.ReadAllText(filePath);
            var jsonObject = JObject.Parse(jsonContent);

            // Check if the key exists in the JSON object
            if (jsonObject.ContainsKey(key))
            {
                // Remove the key
                jsonObject.Remove(key);

                // Write the updated JSON object back to the file
                File.WriteAllText(filePath, jsonObject.ToString());
            }
        }

        #endregion

        #region IO

        // Write
        public override void Write(string key, string value) => WriteToFile(key, value);

        // Read
        public override string ReadString(string key) => ReadFromFile(key);

        // Clear
        public override void Clear(string key) => DeleteKeyFromFile(key);

        // Metadata
        public override bool HasKey(string key) => false;

        #endregion
    }
}