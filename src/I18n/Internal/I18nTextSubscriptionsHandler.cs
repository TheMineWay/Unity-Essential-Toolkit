using System.Collections.Generic;

namespace EssentialToolkit.I18n
{
    internal class I18nTextSubscriptionsHandler
    {
        private List<I18nText> _i18nTexts = new();

        public void AddText(I18nText text) => _i18nTexts.Add(text);

        public void UpdateStates() {
            foreach (var text in _i18nTexts) text.LoadKeyText();
        }

        public void Clear() => _i18nTexts.Clear();
    }
}