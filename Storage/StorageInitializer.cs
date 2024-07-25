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

        [Header("Storage instances")]
        [SerializeField]
        private StorageItem[] _storageItems;

        public override void Initialize()
        {
            StorageService.ClearServices();

            foreach (var storageItem in _storageItems)
            {
                var service = new StorageService(slot: storageItem.slot, storageConnector: storageItem.GetConnector());
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

        [Header("Slot name (unique)")]
        public string slot;

        [Header("Type of storage")]
        public StorageType storageType;

        public IStorageConnector GetConnector()
        {
            switch (storageType)
            {
                case StorageType.PLAYERPREFS: return new PlayerprefsStorageConnector();
            }

            throw new Exception($"Storage service not found: {storageType}");
        }
    }

    enum StorageType
    {
        PLAYERPREFS
    }
}