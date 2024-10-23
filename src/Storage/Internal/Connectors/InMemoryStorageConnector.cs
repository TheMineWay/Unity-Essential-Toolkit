using System.Collections.Generic;

namespace EssentialToolkit.Storage
{
    /**
     * In-memory storage.
     * State is only conserved while the game is running
     */
    public class InMemoryStorageConnector : AStorageConnector
    {
        private readonly Dictionary<string, Dictionary<string, string>> mem = new();
        private Dictionary<string, string> GetSlotDict()
        {
            var slot = GetSlot();
            if (!mem.ContainsKey(slot)) mem[slot] = new();
            return mem[slot];

        }

        #region IO

        // Write
        public override void Write(string key, string value) => GetSlotDict()[key] = value;

        // Read
        public override string ReadString(string key) => HasKey(key) ? GetSlotDict()[key] : null;

        // Clear
        public override void Clear(string key) => GetSlotDict().Remove(key);

        // Metadata
        public  override bool HasKey(string key) => GetSlotDict().ContainsKey(key);

        #endregion
    }
}