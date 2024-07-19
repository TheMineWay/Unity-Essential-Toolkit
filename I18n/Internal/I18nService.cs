namespace EssentialToolkit.I18n
{
    public class I18nService
    {
        private static I18nTextSubscriptionsHandler i18nTextSubscriptionsHandler = new();
        public static I18nTextSubscriptionsHandler GetI18nTextSubscriptionsHandler() => i18nTextSubscriptionsHandler;

        #region Initialization states

        /**
         * Language assets have been loaded?
         */
        public static bool assetsHaveBeenLoaded = false;

        public static bool SceneManagerHasBeenLoaded() => I18nSceneManager.GetInstance() != null;

        #endregion
    }
}