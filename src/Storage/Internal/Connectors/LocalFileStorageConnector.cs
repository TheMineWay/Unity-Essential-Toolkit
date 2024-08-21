using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EssentialToolkit.Storage
{
    public class LocalFileStorageConnector : IStorageConnector
    {
        private const string FILE_NAME = "UET-data-file.json";

        #region Utils

        private string ReadFromFile(string key)
        {
            // Get the path to the file in the current Unity game directory
            var filePath = Path.Combine(Application.dataPath, FILE_NAME);

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
            else
            {
                // If the key doesn't exist, return an empty string or handle it as needed
                Debug.LogWarning($"Key '{key}' not found in the JSON file.");
                return string.Empty;
            }
        }

        private void WriteToFile(string key, string value)
        {
            // Get the path to the file in the current Unity game directory
            string filePath = Path.Combine(Application.dataPath, FILE_NAME);

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

        #endregion

        #region IO

        // Write
        public void Write(string key, string value) => WriteToFile(key, value);
        public void Write(string key, int value) => WriteToFile(key, value.ToString());
        public void Write(string key, float value) => WriteToFile(key, value.ToString());
        public void Write(string key, bool value) => WriteToFile(key, value.ToString());
        public void WriteObject<T>(string key, T value) where T : class => Write(key, JsonConvert.SerializeObject(value, Formatting.None));

        // Read
        public string ReadString(string key) => ReadFromFile(key);
        public int ReadInt(string key) => ParseInt(ReadString(key));
        public float ReadFloat(string key) => ParseFloat(ReadString(key));
        public bool ReadBool(string key) => ParseBool(ReadString(key));
        public T ReadObject<T>(string key) where T : class => ParseJSON<T>(ReadString(key));

        // Clear
        public void Clear(string key) => PlayerPrefs.DeleteKey(key);

        #endregion

        #region Casting

        private int ParseInt(string value) => int.Parse(value);
        private float ParseFloat(string value) => float.Parse(value);
        private bool ParseBool(string value) => value == "true";
        private T ParseJSON<T>(string value) => JsonConvert.DeserializeObject<T>(value);

        #endregion
    }
}