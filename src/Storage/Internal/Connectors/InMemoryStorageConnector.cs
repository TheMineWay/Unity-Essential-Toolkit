using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EssentialToolkit.Storage
{
    /**
     * In-memory storage.
     * State is only conserved while the game is running
     */
    public class InMemoryStorageConnector : AStorageConnector
    {
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, string>>> mem = new();
        private Dictionary<string, string> GetSlotDict()
        {
            var slot = GetSlot();
            if (!mem.ContainsKey(serviceName)) mem[serviceName] = new();
            if (!mem[slot].ContainsKey(slot)) mem[serviceName][slot] = new();

            return mem[serviceName][slot];

        }

        public InMemoryStorageConnector(string serviceName) : base(serviceName) { }

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

        #region Migrations

        public override void Import(string value)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
            GetSlotDict().Clear();
            GetSlotDict().Concat(data);
        }

        public override string Export() => JsonConvert.SerializeObject(GetSlotDict());

        #endregion
    }
}