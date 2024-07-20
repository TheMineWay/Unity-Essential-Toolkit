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

        // Read
        public string ReadString(string key) => PlayerPrefs.GetString(key);
        public int ReadInt(string key) => ParseInt(PlayerPrefs.GetString(key));
        public float ReadFloat(string key) => ParseFloat(PlayerPrefs.GetString(key));
        public bool ReadBool(string key) => ParseBool(PlayerPrefs.GetString(key));

        #endregion

        #region Casting

        private int ParseInt(string value) => int.Parse(value);
        private float ParseFloat(string value) => float.Parse(value);
        private bool ParseBool(string value) => value == "true";

        #endregion
    }
}