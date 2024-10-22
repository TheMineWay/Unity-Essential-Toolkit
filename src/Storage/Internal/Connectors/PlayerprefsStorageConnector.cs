using Newtonsoft.Json;
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
    }
}