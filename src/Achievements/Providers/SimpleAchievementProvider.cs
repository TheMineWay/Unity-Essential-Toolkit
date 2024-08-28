using EssentialToolkit.Core;
using UnityEngine;

namespace EssentialToolkit.Achievements
{
    [System.Serializable]
    internal class SimpleAchievementDictionaryBuilder : ADictionaryBuilder<SimpleAchievement> { }
    public class SimpleAchievementProvider : MonoBehaviour, IAchievementProvider
    {
        [SerializeField]
        private SimpleAchievementDictionaryBuilder[] _achievements;

        bool IAchievementProvider.IsReady()
        {
            return false;
        }
    }

    [System.Serializable]
    internal class SimpleAchievement
    {
        [Header("Achievement unique key")]
        public Achievements key;

        [Header("Title")]
        public string title;

        [Header("Subtitle (can be left empty)")]
        public string subtitle;

        [Header("Icon (can be left empty)")]
        public Sprite icon;
    }
}
