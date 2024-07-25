using EssentialToolkit.Core;
using System;
using UnityEngine;

namespace EssentialToolkit.Storage
{
    public delegate void OnSlotChanged();

    public class StorageInitializer : AInitializer
    {
        #region Slots

        // Invoken on slot value change
        public static OnSlotChanged onSlotChanged;

        private static string currentSlot = "default";
        public static void SetCurrentSlot(string slot) {
            if (currentSlot == slot) return;

            currentSlot = slot;
            onSlotChanged.Invoke();
        }
        public static string GetCurrentSlot() => currentSlot;

        #endregion

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
            if(_defaultSlot.Trim() != "") SetCurrentSlot(_defaultSlot);

            StorageService.ClearServices();

            foreach (var storageItem in _storageItems)
            {
                var service = new StorageService(storageConnector: storageItem.GetConnector());
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
            }

            throw new Exception($"Storage service not found: {storageType}");
        }
    }

    enum StorageType
    {
        PLAYERPREFS
    }
}