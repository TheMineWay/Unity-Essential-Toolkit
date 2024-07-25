using System;
using UnityEngine;
using Newtonsoft.Json.Linq;
using EssentialToolkit.Core;

namespace EssentialToolkit.I18n
{
    public class I18nInitializer : AInitializer
    {
        /**
         * Language assets saved in memory. This value needs to be initialized before using any I18n utility,
         * otherwise strange behaviours might occur.
         */
        private static LanguageAsset[] loadedLanguageAssets = new LanguageAsset[0];
        public static LanguageAsset[] GetLoadedLanguageAssets() => loadedLanguageAssets;

        [SerializeField]
        private LanguageAsset[] languages;

        public override void Initialize() {
            loadedLanguageAssets = languages;
        }
    }

    [Serializable]
    public class TranslationGroup
    {
        [SerializeField]
        public TranslationSets translation;
        public TextAsset languageFile;

        #region Parsing

        public JObject ParseFile()
        {
            return JObject.Parse(languageFile.text);
        }

        #endregion
    }

    [Serializable]
    public class LanguageAsset
    {
        public Language language;

        [SerializeField]
        public TranslationGroup[] translations;
    }
}