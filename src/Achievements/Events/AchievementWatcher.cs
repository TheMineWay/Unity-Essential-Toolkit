using UnityEngine;
using UnityEngine.Events;

namespace EssentialToolkit.Achievements
{
    public class AchievementWatcher : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Achievements _achievement;

        [Header("When the achievement gets unlocked")]
        [SerializeField]
        private UnityEvent _onUnlock;

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
            if (achievement == _achievement) _onUnlock.Invoke();
        }

        #endregion
    }
}