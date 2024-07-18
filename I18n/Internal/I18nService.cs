namespace EssentialToolkit.I18n
{
    public class I18nService
    {
        private static I18nTextSubscriptionsHandler i18nTextSubscriptionsHandler = new();
        public static I18nTextSubscriptionsHandler GetI18nTextSubscriptionsHandler() => i18nTextSubscriptionsHandler;
    }
}