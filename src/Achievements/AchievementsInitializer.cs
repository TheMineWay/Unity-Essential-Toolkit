using EssentialToolkit.Core;
using EssentialToolkit.I18n;
using EssentialToolkit.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Achievements
{
    public class AchievementsInitializer : AInitializer
    {
        // Initialized achievements
        private static Dictionary<Achievements, Achievement> achievements = new();
        public static Achievement GetAchievement(Achievements achievement) => achievements[achievement];

        [SerializeField]
        [Header("Storage service name")]
        private string _storageName = "achievements";

        private IAchievementProvider _achievementProvider;

#if UNITY_EDITOR
        // Initialization count
        private static int _timesInitializated = 0;
#endif

        #region Initialization
        public override void Initialize()
        {
            StartCoroutine(InternalInitialize());
        }

        private IEnumerator InternalInitialize()
        {
            _achievementProvider = GetComponent<IAchievementProvider>();

            yield return new WaitUntil(StorageInitializer.IsInitialized); // <-- Wait for storage to be initialized
            yield return new WaitUntil(_achievementProvider.IsReady); // <-- Wait for achievements provider to be ready

            LoadCache();

            // Subscribe to language change delegate
            I18nService.onLanguageChange += LoadCache;

            // Create achievements instance
            AchievementsService.CreateInstance(_storageName);

#if UNITY_EDITOR
            if (_timesInitializated > 0)
            {
                Debug.LogWarning("AchievementsInitializer called the Initialize function twice. This might happen when calling the Initialize function from another script. If that is the case, check that initializeOn has been set to NO_AUTO_INITIALIZATION. If this does not remove this warning, check that you are not calling the Initialize function more than once.");
            }
            _timesInitializated += 1;
# endif
        }

        private void OnDestroy()
        {
            I18nService.onLanguageChange -= LoadCache;
        }

        #endregion

        #region Internal utils

        private void LoadCache()
        {
            // Load achievements in cache
            achievements = _achievementProvider.GetAchievements();
        }

        #endregion
    }

    [Serializable]
    public class Achievement
    {
        #region Properties

        [Header("Unique achievement identifier")]
        public Achievements key;

        [Header("Translation key")]
        public string title;

        [Header("Translation key (subtitle). Will not be used if left empty")]
        public string subtitle = "";

        [Header("Achievement icon")]
        public Sprite image;

        #endregion

        #region Getters

        public Achievements GetKey() => key;
        public string GetTitle() => title;
        public string GetSubtitle() => subtitle;
        public Sprite GetImage() => image;

        #endregion

        #region Checkers

        public bool HasSubtitle() => subtitle.Trim() != "";
        public bool HasImage() => image != null;

        #endregion
    }
}