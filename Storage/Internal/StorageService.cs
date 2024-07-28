using System.Collections.Generic;
using System.Linq;

namespace EssentialToolkit.Storage
{
    public delegate void OnSlotChanged();
    public class StorageService
    {
        public StorageService(IStorageConnector storageConnector = null, string slot = null) {
            if (storageConnector != null) _storageConnector = storageConnector;

            this.slot = slot ?? "";
        }

        #region Self instance

        private static Dictionary<string, StorageService> _services = new();

        public static void ClearServices() => _services.Clear();
        public static void AddService(string serviceName, StorageService service) => _services.Add(serviceName, service);
        public static void RemoveService(string serviceName) => _services.Remove(serviceName);
        public static StorageService GetService(string serviceName) => _services[serviceName];
        public static StorageService[] GetServices() => _services.Values.ToArray();
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
                var value = _storageConnector.ReadObject<T>(GenerateKey(key));

                if (value == null) return fallback;
                return value;
            } catch (System.Exception e)
            {
                UnityEngine.Debug.LogError("Error while reading " + key);
                UnityEngine.Debug.LogException(e);

                // Cleaning on error removes the data from the stored data when an error occurs.
                // This avoids corrupt data from persisting
                if (clearOnError) _storageConnector.Clear(key);

                if (fallback != null) return fallback;

                throw e;
            }
        }

        // Clear

        public void Clear(string key) => _storageConnector.Clear(GenerateKey(key));

        #endregion

        #region Utils

        private string GenerateKey(string key) => $"{slot}::${key}";

        #endregion

        #region Slot

        private string slot;

        public void SetSlot(string slot) => this.slot = slot;
        public string GetSlot() => slot;

        #endregion

        // - [ CORE UTILS ] ---------

        // Invoken on slot value change
        public static OnSlotChanged onSlotChanged;

        private static string currentSlot = "default";
        public static void SetCurrentSlot(string slot, bool updateStorageInstances = true)
        {
            if (currentSlot == slot) return;

            currentSlot = slot;

            // Update all initialized storage services slots
            if (updateStorageInstances)
            {
                foreach (var service in GetServices()) service.SetSlot(slot);
            }

            onSlotChanged.Invoke();
        }
        public static string GetCurrentSlot() => currentSlot;
    }
}