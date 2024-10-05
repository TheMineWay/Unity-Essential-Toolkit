using EssentialToolkit.Core;
using EssentialToolkit.I18n;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Achievements
{
    [System.Serializable]
    internal class I18nAchievementDictionaryBuilder : ADictionaryBuilder<Achievements, I18nAchievement> { }
    public class I18nAchievementProvider : MonoBehaviour, IAchievementProvider
    {
        #region Properties
        
        [SerializeField]
        private TranslationSets translationSet;

        [SerializeField]
        private I18nAchievementDictionaryBuilder[] _achievements;

        #endregion

        #region IAchievementProvider

        Dictionary<Achievements, Achievement> IAchievementProvider.GetAchievements()
        {
            var dict = new Dictionary<Achievements, Achievement>();

            foreach (var item in _achievements)
            {
                var val = item.GetValue();

                // Create the standard Achievement Object
                dict[item.GetKey()] = new Achievement
                {
                    key = item.GetKey(),

                    title = I18nService.Translate(val.titleKey, translationSet),
                    subtitle = I18nService.Translate(val.subtitleKey, translationSet),
                    image = val.icon,
                };
            }

            return dict;
        }

        bool IAchievementProvider.IsReady() => true;

        #endregion
    }

    [System.Serializable]
    internal class I18nAchievement
    {
        [Header("Title i18n key")]
        public string titleKey;

        [Header("Subtitle i18n key (can be left empty)")]
        public string subtitleKey;

        [Header("Icon (can be left empty)")]
        public Sprite icon;
    }
}
