using EssentialToolkit.Storage;
using System;
using System.Collections.Generic;

namespace EssentialToolkit.Achievements
{
    public delegate void OnAchievementUnlocked(Achievements achievements);
    public class AchievementsService
    {

        private const string UNLOCKED_ACHIEVEMENTS_STORAGE_KEY = "unlocked-achievements";

        #region Events

        public static OnAchievementUnlocked OnAchievementUnlocked;

        #endregion

        #region Instance

        private static AchievementsService _instance = null;

        public static AchievementsService GetInstance() => _instance;
        private static void AssignInstance(AchievementsService instance)
        {
#if UNITY_EDITOR
            bool alreadyHasInstance = _instance != null;
#endif

            _instance = instance;

#if UNITY_EDITOR
            // Warn when replacing existing instance
            if (alreadyHasInstance) UnityEngine.Debug.LogWarning("The existing AchievementsService instance has been replaced with a new one. This might have happened because Achievements have been initialized twice.");
# endif
        }

        public static AchievementsService CreateInstance(StorageService storageService) {
            var instance = new AchievementsService(storageService);

            AssignInstance(instance);

            return instance;
        }
        public static AchievementsService CreateInstance(string storageServiceName)
        {
            var instance = CreateInstance(StorageService.GetService(storageServiceName));
            return instance;
        }

        #endregion

        private readonly StorageService storageService;

        #region Constructors

        private AchievementsService(StorageService storageService)
        {
            this.storageService = storageService;

            // Setup slot listener
            StorageInitializer.onSlotChanged += LoadGivenAchievements;

            // Initial load
            LoadGivenAchievements();
        }

        #endregion

        #region Given achievements

        private List<StoredAchievement> _unlockedAchievements = new();

        private void LoadGivenAchievements()
        {
            _unlockedAchievements.Clear();

            // Read given achievements and load them to memory
            var storedGivenAchievements = storageService.ReadObject(UNLOCKED_ACHIEVEMENTS_STORAGE_KEY, fallback: new StoredAchievement[0]);
            _unlockedAchievements.AddRange(storedGivenAchievements);
        }

        #endregion

        #region API

        // If the achievement has been already unlocked it returns false, otherwise it returns true
        public bool UnlockAchievement(Achievements achievement)
        {
            if (HasAchievement(achievement)) return false;

            var newAchievement = new StoredAchievement { code = achievement, givenAt = DateTime.Now };

            // Add achievement to in-memory achievements
            _unlockedAchievements.Add(newAchievement);

            // Write achievements in storage
            storageService.WriteObject(UNLOCKED_ACHIEVEMENTS_STORAGE_KEY, _unlockedAchievements);

            // Call event
            OnAchievementUnlocked.Invoke(achievement);

            return true;
        }

        public void LockAchievement(Achievements achievement)
        {
            var index = _unlockedAchievements.FindIndex((ach) => ach.code == achievement);

            if (index == -1) return;

            // Remove achievement from in-memory achievements
            _unlockedAchievements.RemoveAt(index);

            // Write achievements in storage
            storageService.WriteObject(UNLOCKED_ACHIEVEMENTS_STORAGE_KEY, _unlockedAchievements);
        }

        public void ClearAchievements()
        {
            _unlockedAchievements.Clear();
            storageService.Clear(UNLOCKED_ACHIEVEMENTS_STORAGE_KEY);
        }

        public bool HasAchievement(Achievements achievement)
        {
            foreach (var ach in _unlockedAchievements)
            {
                if (ach.code == achievement) return true;
            }
            return false;
        }

        #endregion
    }

    class StoredAchievement
    {
        public Achievements code;
        public DateTime givenAt;
    }
}