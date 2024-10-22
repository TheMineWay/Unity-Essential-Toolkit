using UnityEngine;

namespace EssentialToolkit.Storage
{
    public class PlayerprefsStorageConnector : AStorageConnector
    {
        #region IO

        // Write
        public override void Write(string key, string value) => PlayerPrefs.SetString(key, value);

        // Read
        public override string ReadString(string key) => HasKey(key) ? PlayerPrefs.GetString(key) : null;

        // Clear
        public override void Clear(string key) => PlayerPrefs.DeleteKey(key);

        // Metadata
        public override bool HasKey(string key) => PlayerPrefs.HasKey(key);

        #endregion

        #region Casting

        private int ParseInt(string value) => int.Parse(value);
        private float ParseFloat(string value) => float.Parse(value);
        private bool ParseBool(string value) => value == "true";
        private T ParseJSON<T>(string value) => JsonConvert.DeserializeObject<T>(value);

        #endregion
    }
}