using System;
using UnityEngine;

namespace EssentialToolkit.I18n
{
    public class I18nInitializer : MonoBehaviour
    {
        /**
         * Language assets saved in memory. This value needs to be initialized before using any I18n utility,
         * otherwise strange behaviours might occur.
         */
        private static LanguageAsset[] loadedLanguageAssets = new LanguageAsset[0];
        public static LanguageAsset[] GetLoadedLanguageAssets() => loadedLanguageAssets;

        [SerializeField]
        private LanguageAsset[] languages;

        [SerializeField]
        private bool loadOnStartup = true;

        private void Awake()
        {
            if (loadOnStartup) Initialize();
        }

        public void Initialize() {
            loadedLanguageAssets = languages;
        }
    }

    [Serializable]
    public class TranslationGroup
    {
        [SerializeField]
        public TranslationSets translation;
        public TextAsset languageFile;
    }

    [Serializable]
    public class LanguageAsset
    {
        public Language language;

        [SerializeField]
        public TranslationGroup[] translations;

        #region Parsing

        public object ParseFile() { 
            return null; // <- TODO: implement JSON parsing logic
        }

        #endregion

    }
}