namespace EssentialToolkit.Storage
{
    public interface IStorageConnector
    {
        #region IO

        // Write
        public void Write(string key, string value);
        public void Write(string key, int value);
        public void Write(string key, bool value);

        // Read
        public string ReadString(string key);
        public int ReadInt(string key);
        public bool ReadBool(string key);

        #endregion
    }
}