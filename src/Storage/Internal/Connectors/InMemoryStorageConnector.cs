using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EssentialToolkit.Storage
{
    /**
     * In-memory storage.
     * State is only conserved while tha game is running
     */
    public class InMemoryStorageConnector : IStorageConnector
    {
        private Dictionary<string, string> mem = new();

        #region IO

        // Write
        public void Write(string key, string value) => mem[key] = value;
        public void Write(string key, int value) => Write(key, value.ToString());
        public void Write(string key, float value) => Write(key, value.ToString());
        public void Write(string key, bool value) => Write(key, value.ToString());
        public void WriteObject<T>(string key, T value) where T : class => Write(key, JsonConvert.SerializeObject(value, Formatting.None));

        // Read
        public string ReadString(string key) => HasKey(key) ? mem[key] : null;
        public int? ReadInt(string key) => NullableKey((v) => ParseInt(v), key);
        public float? ReadFloat(string key) => NullableKey((v) => ParseFloat(v), key);
        public bool? ReadBool(string key) => NullableKey((v) => ParseBool(v), key);
        public T ReadObject<T>(string key) where T : class
        {
            string value = ReadString(key);
            if (value == null) return null;

            return ParseJSON<T>(value);
        }

        // Clear
        public void Clear(string key) => mem.Remove(key);

        // Metadata
        public bool HasKey(string key) => false;

        #endregion

        #region Casting

        private int ParseInt(string value) => int.Parse(value);
        private float ParseFloat(string value) => float.Parse(value);
        private bool ParseBool(string value) => value == "true";
        private T ParseJSON<T>(string value) => JsonConvert.DeserializeObject<T>(value);

        #endregion

        #region Utils
        public T? NullableKey<T>(Func<string, T> action, string key) where T : struct
        {
            if (!HasKey(key)) return null;
            return action(ReadString(key));
        }
        #endregion
    }
}