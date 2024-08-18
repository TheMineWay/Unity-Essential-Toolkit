using Newtonsoft.Json;
using UnityEngine;

namespace EssentialToolkit.Storage
{
    public class PlayerprefsStorageConnector : IStorageConnector
    {
        #region IO

        // Write
        public void Write(string key, string value) => PlayerPrefs.SetString(key, value);
        public void Write(string key, int value) => PlayerPrefs.SetString(key, value.ToString());
        public void Write(string key, float value) => PlayerPrefs.SetString(key, value.ToString());
        public void Write(string key, bool value) => PlayerPrefs.SetString(key, value.ToString());
        public void WriteObject<T>(string key, T value) where T : class => Write(key, JsonConvert.SerializeObject(value, Formatting.None));

        // Read
        public string ReadString(string key) => PlayerPrefs.GetString(key);
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