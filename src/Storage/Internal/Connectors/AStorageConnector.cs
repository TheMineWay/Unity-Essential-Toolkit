using Newtonsoft.Json;
using System;

namespace EssentialToolkit.Storage
{
    public abstract class AStorageConnector
    {
        #region IO

        // Write
        public abstract void Write(string key, string value);
        public virtual void Write(string key, int value) => Write(key, value.ToString());
        public virtual void Write(string key, float value) => Write(key, value.ToString());
        public virtual void Write(string key, bool value) => Write(key, value.ToString());

        public void WriteObject<T>(string key, T obj) where T : class => Write(key, JsonConvert.SerializeObject(obj, Formatting.None));

        // Read
        public abstract string ReadString(string key);
        public virtual int? ReadInt(string key) => NullableKey((v) => ParseInt(v), key);
        public virtual float? ReadFloat(string key) => NullableKey((v) => ParseFloat(v), key);
        public virtual bool? ReadBool(string key) => NullableKey((v) => ParseBool(v), key);
        public virtual T ReadObject<T>(string key) where T : class
        {
            string value = ReadString(key);
            if (value == null) return null;

            return ParseJSON<T>(value);
        }

        // Clear
        public abstract void Clear(string key);

        // Metadata
        public abstract bool HasKey(string key);

        #endregion

        #region Casting

        protected int ParseInt(string value) => int.Parse(value);
        protected float ParseFloat(string value) => float.Parse(value);
        protected bool ParseBool(string value) => value == "true";
        protected T ParseJSON<T>(string value) => JsonConvert.DeserializeObject<T>(value);

        #endregion

        #region Utils
        protected T? NullableKey<T>(Func<string, T> action, string key) where T : struct
        {
            if (!HasKey(key)) return null;
            return action(ReadString(key));
        }
        #endregion
    }
}