using EssentialToolkit.Core;
using System;
using UnityEngine;

namespace EssentialToolkit.Storage
{
    public class StorageInitializer : AInitializer
    {
        private static bool initialized = false;
        public static bool IsInitialized() => initialized;
        public static bool SetInitialization(bool state = true) => initialized = state;

        [SerializeField]
        [Header("Default slot name")]
        private string _defaultSlot = "default";

        [Header("Storage instances")]
        [SerializeField]
        private StorageItem[] _storageItems;

        public override void Initialize()
        {
            // Store default slot name in current slot if present
            if(_defaultSlot.Trim() != "") StorageService.SetCurrentSlot(_defaultSlot, updateStorageInstances: false);

            StorageService.ClearServices();

            foreach (var storageItem in _storageItems)
            {
                var service = new StorageService(storageConnector: storageItem.GetConnector(), slot: StorageService.GetCurrentSlot());
                StorageService.AddService(storageItem.name, service);
            }

            SetInitialization(true);
        }
    }

    [Serializable]
    class StorageItem
    {
        [Header("Name of the service (unique)")]
        public string name;

        [Header("Type of storage")]
        public StorageType storageType;

        public IStorageConnector GetConnector()
        {
            switch (storageType)
            {
                case StorageType.PLAYERPREFS: return new PlayerprefsStorageConnector();
                case StorageType.IN_MEMORY: return new InMemoryStorageConnector();
                case StorageType.JSON_FILE: return new LocalFileStorageConnector();
            }

            throw new Exception($"Storage service not found: {storageType}");
        }
    }

    enum StorageType
    {
        PLAYERPREFS,
        JSON_FILE,
        IN_MEMORY
    }
}