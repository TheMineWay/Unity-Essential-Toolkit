using System.Collections.Generic;
using System.Linq;

namespace EssentialToolkit.Storage
{
    public class StorageService
    {
        public StorageService(string slot = "default", IStorageConnector storageConnector = null){
            _currentSlot = slot;

            if (storageConnector != null) _storageConnector = storageConnector;
        }

        #region Self instance

        private static Dictionary<string, StorageService> _services = new();

        public static void ClearServices() => _services.Clear();
        public static void AddService(string serviceName, StorageService service) => _services.Add(serviceName, service);
        public static void RemoveService(string serviceName) => _services.Remove(serviceName);
        public static StorageService GetService(string serviceName) => _services[serviceName];
        public static string[] GetServiceNames() => _services.Keys.ToArray();

        #endregion

        #region Connector

        private IStorageConnector _storageConnector = new PlayerprefsStorageConnector();
        public void SetConnector(IStorageConnector connector) => _storageConnector = connector;

        #endregion

        #region IO

        // Write
        public void Write(string key, string value) => _storageConnector.Write(GenerateKey(key), value);
        public void Write(string key, int value) => _storageConnector.Write(GenerateKey(key), value);
        public void Write(string key, bool value) => _storageConnector.Write(GenerateKey(key), value);

        // Read
        public string ReadString(string key) => _storageConnector.ReadString(GenerateKey(key));
        public int ReadInt(string key) => _storageConnector.ReadInt(GenerateKey(key));
        public bool ReadBool(string key) => _storageConnector.ReadBool(GenerateKey(key));

        #endregion

        #region Utils

        private string GenerateKey(string key) => $"{_currentSlot}::${key}";

        #endregion

        #region Slots

        private string _currentSlot;

        #endregion
    }
}