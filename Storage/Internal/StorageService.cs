using System.Collections.Generic;
using System.Linq;

namespace EssentialToolkit.Storage
{
    public class StorageService
    {
        public StorageService(IStorageConnector storageConnector = null){
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
        public void Write(string key, float value) => _storageConnector.Write(GenerateKey(key), value);
        public void Write(string key, bool value) => _storageConnector.Write(GenerateKey(key), value);
        public void WriteObject<T>(string key, T value) where T : class => _storageConnector.WriteObject(GenerateKey(key), value);

        // Read
        public string ReadString(string key) => _storageConnector.ReadString(GenerateKey(key));
        public int ReadInt(string key) => _storageConnector.ReadInt(GenerateKey(key));
        public float ReadFloat(string key) => _storageConnector.ReadFloat(GenerateKey(key));
        public bool ReadBool(string key) => _storageConnector.ReadBool(GenerateKey(key));

        public T ReadObject<T>(string key, bool clearOnError = true, T fallback = null) where T : class
        {
            try
            {
                return _storageConnector.ReadObject<T>(GenerateKey(key));
            } catch (System.Exception e)
            {
                // Cleaning on error removes the data from the stored data when an error occurs.
                // This avoids corrupt data from persisting
                if (clearOnError) _storageConnector.Clear(key);

                if (fallback != null) return fallback;

                throw e;
            }
        }

        #endregion

        #region Utils

        private string GenerateKey(string key) => $"{StorageInitializer.GetCurrentSlot()}::${key}";

        #endregion
    }
}