using EssentialToolkit.Storage;

namespace EssentialToolkit.Achievements
{
    public class AchievementsService
    {

        #region Instance

        private static AchievementsService _instance = null;

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
        }

        private AchievementsService(string storageServiceName)
        {
            storageService = StorageService.GetService(storageServiceName);
        }

        #endregion
    }
}