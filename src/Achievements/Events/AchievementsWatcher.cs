using UnityEngine;
using UnityEngine.Events;

namespace EssentialToolkit.Achievements
{
    public class AchievementsWatcher : MonoBehaviour
    {
        #region Fields
        [Header("When any achievement gets unlocked")]
        [SerializeField]
        private UnityEvent<Achievements> _onUnlock;

        #endregion

        #region Initialization
        private void Awake()
        {
            AchievementsService.OnAchievementUnlocked += OnAchievementUnlock;
        }

        private void OnDestroy()
        {
            AchievementsService.OnAchievementUnlocked -= OnAchievementUnlock;
        }

        #endregion

        #region Event watchers
        void OnAchievementUnlock(Achievements achievement)
        {
            _onUnlock.Invoke(achievement);
        }

        #endregion
    }
}