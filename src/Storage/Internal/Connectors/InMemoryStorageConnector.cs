using System.Collections.Generic;

namespace EssentialToolkit.Storage
{
    /**
     * In-memory storage.
     * State is only conserved while tha game is running
     */
    public class InMemoryStorageConnector : AStorageConnector
    {
        private Dictionary<string, string> mem = new();

        #region IO

        // Write
        public override void Write(string key, string value) => mem[key] = value;

        // Read
        public override string ReadString(string key) => HasKey(key) ? mem[key] : null;

        // Clear
        public override void Clear(string key) => mem.Remove(key);

        // Metadata
        public  override bool HasKey(string key) => false;

        #endregion
    }
}