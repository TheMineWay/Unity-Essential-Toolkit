using System.Collections.Generic;

namespace EssentialToolkit.I18n
{
    public class I18nTextSubscriptionsHandler
    {
        private List<I18nText> _i18nTexts = new();

        public void AddText(I18nText text) => _i18nTexts.Add(text);
    }
}