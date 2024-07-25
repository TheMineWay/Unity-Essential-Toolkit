namespace EssentialToolkit.Storage
{
    public interface IStorageConnector
    {
        #region IO

        // Write
        public void Write(string key, string value);
        public void Write(string key, int value);
        public void Write(string key, float value);
        public void Write(string key, bool value);

        public void WriteObject<T>(string key, T obj) where T : class;

        // Read
        public string ReadString(string key);
        public int ReadInt(string key);
        public float ReadFloat(string key);
        public bool ReadBool(string key);

        public T ReadObject<T>(string key) where T : class;

        // Clear
        public void Clear(string key);

        #endregion
    }
}