using UnityEngine;
using UnityEngine.Events;

namespace EssentialToolkit.Achievements
{
    public class AchievementSceneObject : MonoBehaviour
    {
        [SerializeField]
        private Achievements _achievement;

        [SerializeField]
        private UnityEvent onUnlocked, onUnlockCall, beforeUnlockCall;

        public void UnlockAchievement()
        {
            beforeUnlockCall?.Invoke();

            var unlocked = AchievementsService.GetInstance().UnlockAchievement(_achievement);
            
            onUnlockCall?.Invoke();

            if (unlocked) onUnlocked?.Invoke();
        }
    }
}