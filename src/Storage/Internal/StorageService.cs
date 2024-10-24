using System.Collections.Generic;
using System.Linq;

namespace EssentialToolkit.Storage
{
    internal delegate void OnSlotChanged(string slot);
    internal class StorageService
    {
        public StorageService(AStorageConnector storageConnector = null, string slot = null) {
            if (storageConnector != null) _storageConnector = storageConnector;

            this.slot = slot ?? "";
        }

        #region Connector

        private AStorageConnector _storageConnector = new PlayerprefsStorageConnector("default");
        public void SetConnector(AStorageConnector connector) => _storageConnector = connector;

        #endregion

        #region IO

        // Write
        public void Write(string key, string value) => _storageConnector.Write(key, value);
        public void Write(string key, int value) => _storageConnector.Write(key, value);
        public void Write(string key, float value) => _storageConnector.Write(key, value);
        public void Write(string key, bool value) => _storageConnector.Write(key, value);
        public void WriteObject<T>(string key, T value) where T : class => _storageConnector.WriteObject(key, value);

        // Read
        public string ReadString(string key) => _storageConnector.ReadString(key);
        public int? ReadInt(string key) => _storageConnector.ReadInt(key);
        public float? ReadFloat(string key) => _storageConnector.ReadFloat(key);
        public bool? ReadBool(string key) => _storageConnector.ReadBool(key);

        public T ReadObject<T>(string key, bool clearOnError = true, T fallback = null) where T : class
        {
            try
            {
                var value = _storageConnector.ReadObject<T>(key);

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

        public void Clear(string key) => _storageConnector.Clear(key);

        #endregion

        #region Migrations

        public string Export() => _storageConnector.Export();
        public void Import(string value) => _storageConnector.Import(value);
        public void Import<T>(T value) where T : class => _storageConnector.Import(value);

        public void CopyTo(StorageService target) => _storageConnector.CopyTo(target);

        # endregion

        #region Slot

        private string slot;

        public void SetSlot(string slot) => this.slot = slot;
        public string GetSlot() => slot;

        #endregion

        // - [ CORE API ] ---------

        #region Slot API

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

            onSlotChanged.Invoke(slot);
        }
        public static string GetCurrentSlot() => currentSlot;

        #endregion

        #region Services management

        private static Dictionary<string, StorageService> _services = new();

        public static void ClearServices() => _services.Clear();
        public static void AddService(string serviceName, StorageService service) => _services.Add(serviceName, service);
        public static void RemoveService(string serviceName) => _services.Remove(serviceName);
        public static StorageService GetService(string serviceName) => _services[serviceName];
        public static StorageService[] GetServices() => _services.Values.ToArray();
        public static string[] GetServiceNames() => _services.Keys.ToArray();

        #endregion
    }
}