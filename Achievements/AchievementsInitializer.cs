using EssentialToolkit.Core;
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
        private static readonly Dictionary<Achievements, Achievement> achievements = new();

        [SerializeField]
        [Header("Storage service name")]
        private string _storageName = "achievements";

        [SerializeField]
        [Header("Achievements list")]
        private Achievement[] _achievements;

#if UNITY_EDITOR
        // Initialization count
        private static int _timesInitializated = 0;
# endif

        public override void Initialize()
        {
            StartCoroutine(InternalInitialize());
        }

        private IEnumerator InternalInitialize()
        {
            yield return new WaitUntil(StorageInitializer.IsInitialized);

            foreach (var achievement in _achievements)
            {
                achievements[achievement.GetKey()] = achievement;
            }

            AchievementsService.CreateInstance(_storageName);

#if UNITY_EDITOR
            if (_timesInitializated > 0)
            {
                Debug.LogWarning("AchievementsInitializer called the Initialize function twice. This might happen when calling the Initialize function from another script. If that is the case, check that initializeOn has been set to NO_AUTO_INITIALIZATION. If this does not remove this warning, check that you are not calling the Initialize function more than once.");
            }
            _timesInitializated += 1;
# endif
        }
    }

    [Serializable]
    public class Achievement
    {
        #region Properties

        [SerializeField]
        [Header("Unique achievement identifier")]
        private Achievements _key;

        [SerializeField]
        [Header("Translation key")]
        private string _i18nKey;

        [SerializeField]
        [Header("Translation key (subtitle). Will not be used if left empty")]
        private string _subtitleI18nKey = "";

        [SerializeField]
        [Header("Achievement icon")]
        private Sprite _image;

        #endregion

        #region Getters

        public Achievements GetKey() => _key;
        public string GetI18nKey() => _i18nKey;
        public string GetSubtitleI18nKey() => _subtitleI18nKey;
        public Sprite GetImage() => _image;

        #endregion

        #region Checkers

        public bool HasSubtitleI18nKey() => _subtitleI18nKey.Trim() != "";
        public bool HasImage() => _image != null;

        #endregion
    }
}