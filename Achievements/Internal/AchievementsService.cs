using EssentialToolkit.Storage;

namespace EssentialToolkit.Achievements
{
    public class AchievementsService
    {
        private readonly StorageService storageService;

        #region Constructors

        public AchievementsService(StorageService storageService)
        {
            this.storageService = storageService;
        }

        public AchievementsService(string storageServiceName)
        {
            storageService = StorageService.GetService(storageServiceName);
        }

        #endregion

        
    }
}