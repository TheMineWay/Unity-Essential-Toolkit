using EssentialToolkit.Core;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Achievements
{
    [System.Serializable]
    internal class SimpleAchievementDictionaryBuilder : ADictionaryBuilder<Achievements, SimpleAchievement> { }
    public class SimpleAchievementProvider : MonoBehaviour, IAchievementProvider
    {
        [SerializeField]
        private SimpleAchievementDictionaryBuilder[] _achievements;

        Dictionary<Achievements, Achievement> IAchievementProvider.GetAchievements()
        {
            var dict = new Dictionary<Achievements, Achievement>();

            foreach (var item in _achievements)
            {
                var val = item.GetValue();

                // Create the standard Achievement Object
                dict[item.GetKey()] = new Achievement {
                    key = item.GetKey(),

                    title = val.title,
                    subtitle = val.subtitle,
                    image = val.icon,
                };
            }

            return dict;
        }

        bool IAchievementProvider.IsReady() => true;
    }

    [System.Serializable]
    internal class SimpleAchievement
    {
        [Header("Title")]
        public string title;

        [Header("Subtitle (can be left empty)")]
        public string subtitle;

        [Header("Icon (can be left empty)")]
        public Sprite icon;
    }
}
