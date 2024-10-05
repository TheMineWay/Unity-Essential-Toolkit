using EssentialToolkit.I18n;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EssentialToolkit.Achievements
{
    public class AchievementsSceneController : MonoBehaviour
    {
        private const string ANIMATOR_UNLOCK_TRIGGER_KEY = "unlock";

        #region Properties

        [SerializeField]
        private TextObject _title;

        [SerializeField]
        private TextObject _subtitle;

        [SerializeField]
        private Image _image;

        [SerializeField]
        [Header("Triggers will be called to toggle UI states")]
        private Animator _animator;

        [SerializeField]
        [Header("Called when an achivement is unlocked")]
        private UnityEvent<Achievements> _onAchievementUnlocked;

        #endregion

        #region Start & end

        private void Awake()
        {
            AchievementsService.OnAchievementUnlocked += OnUnlocked;
        }

        private void OnDestroy()
        {
            AchievementsService.OnAchievementUnlocked -= OnUnlocked;
        }

        #endregion

        #region Achievement properties utils

        private void DisplayAchievementProperties(Achievements achievement)
        {
            var _achievement = AchievementsInitializer.GetAchievement(achievement);

            // Update fields
            _title.SetText(_achievement.GetTitle());
            if (_subtitle != null && _achievement.HasSubtitle()) _subtitle.SetText(_achievement.GetSubtitle());
            if (_image != null && _achievement.HasImage()) _image.sprite = _achievement.GetImage();
        }

        #endregion

        #region Events

        private void OnUnlocked(Achievements achievement) {
            DisplayAchievementProperties(achievement);

            _onAchievementUnlocked.Invoke(achievement);

            if (_animator != null)
            {
                _animator.ResetTrigger(ANIMATOR_UNLOCK_TRIGGER_KEY);
                _animator.SetTrigger(ANIMATOR_UNLOCK_TRIGGER_KEY);
            }
        }

        #endregion
    }
}