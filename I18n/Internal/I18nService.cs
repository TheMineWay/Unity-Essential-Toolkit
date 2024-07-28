using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace EssentialToolkit.I18n
{
    public class I18nService
    {

        #region Language state

        private static Language _language;
        public static void SetLanguage(Language language) {
            _language = language;

            ChangeInMemoryTranslationsLanguage();

            NotifyI18nStateChanges();
        }
        public static Language GetLanguage() => _language;

        public static LanguageAsset GetLanguageAsset(Language language)
        {
            var languageAssets = I18nInitializer.GetLoadedLanguageAssets();
            return Array.Find(languageAssets, (i) => i.language == language);
        }

        #endregion

        #region Global replacements

        private static Dictionary<string, string> _globalReplacements = new();

        public static Dictionary<string, string> GetGlobalReplacements = _globalReplacements;
        public static void SetGlobalReplacement(string key, string value)
        {
            _globalReplacements[key] = value;

            NotifyI18nStateChanges();
        }
        public static void RemoveGlobalReplacement(string key)
        {
            _globalReplacements.Remove(key);

            NotifyI18nStateChanges();
        }
        public static void ClearGlobalReplacements()
        {
            _globalReplacements.Clear();

            NotifyI18nStateChanges();
        }

        #endregion

        private static I18nTextSubscriptionsHandler i18nTextSubscriptionsHandler = new();
        public static I18nTextSubscriptionsHandler GetI18nTextSubscriptionsHandler() => i18nTextSubscriptionsHandler;

        #region Initialization states

        /**
         * Language assets have been loaded?
         */
        public static bool AssetsHaveBeenLoaded() => I18nInitializer.GetLoadedLanguageAssets().Length > 0;
        public static bool SceneAssetsHaveBeenLoaded() => I18nService.inMemoryTranslations.Keys.Count > 0;

        public static bool SceneManagerHasBeenLoaded() => I18nSceneManager.GetInstance() != null;

        #endregion

        #region Translations manager

        public static void LoadTranslations(TranslationSets[] translations) {
            CleanupInMemoryTranslations(translations);
            LoadNecessaryTranslations(translations);
        }

        /**
         * Translations are kept here while loaded.
         */
        private static Dictionary<TranslationSets, JObject> inMemoryTranslations = new();

        /**
         * Add to in-memory translations specified translations.
         */
        private static void LoadNecessaryTranslations(TranslationSets[] translations)
        {
            var loadedTranslationKeys = inMemoryTranslations.Keys;
            var missingTranslations = (from translation in translations where !loadedTranslationKeys.Contains(translation) select translation).ToList();

            // Get current language asset
            var language = GetLanguage();
            var currentLanguageAsset = GetLanguageAsset(language);

            // Ensure the script does not initialize the state with null values
            if (currentLanguageAsset == null) throw new Exception($"Cannot find {language} language in loaded language assets");

            foreach (var missingTranslation in missingTranslations)
            {
                // Find translation item
                var currentTranslation = Array.Find(currentLanguageAsset.translations, (t) => t.translation == missingTranslation);

                // Ensure the script does not initialize the state with null values
                if (currentTranslation == null) throw new Exception($"Cannot find {missingTranslation} translation in {language} language");

                inMemoryTranslations.Add(missingTranslation, currentTranslation.ParseFile());
            }
        }

        /**
         * Delete all loaded translations from memory.
         */
        private static void CleanupInMemoryTranslations(TranslationSets[] keepTranslations = null)
        {
            if (keepTranslations == null) inMemoryTranslations.Clear();
            else
            {
                foreach (var translation in inMemoryTranslations.Keys)
                {
                    // Ignore keys that are suppossed to be kept
                    if (keepTranslations.Contains(translation)) continue;

                    // Delete translation fom memory
                    inMemoryTranslations.Remove(translation);
                }
            }
        }

        private static void ChangeInMemoryTranslationsLanguage()
        {
            var loadedSets = inMemoryTranslations.Keys.ToArray();

            CleanupInMemoryTranslations();
            LoadNecessaryTranslations(loadedSets);
        }

        #endregion

        #region Translation utils

        public static string Translate(string key, TranslationSets translationSet, Dictionary<string, string> replacements = null)
        {
            string[] keys = key.Split('.');
            JToken token = inMemoryTranslations[translationSet];

            if (token == null) return key;

            foreach (var k in keys)
            {
                token = token[k];
                if (token == null)
                {
                    return key;
                }
            }

            return ReplaceTranslationPlaceholders(token.ToString(), replacements ?? new());
        }

        public static string ReplaceTranslationPlaceholders(string input, Dictionary<string, string> replacements)
        {
            // Escaping backslashes before placeholders
            string pattern = @"\\(\{[^\}]+\})";
            string escapedInput = Regex.Replace(input, pattern, m => "\\" + m.Groups[1].Value);

            // Replacing placeholders with dictionary values
            foreach (var pair in replacements)
            {
                string placeholder = "{" + pair.Key + "}";
                escapedInput = escapedInput.Replace(placeholder, pair.Value);
            }

            // Unescaping the escaped placeholders
            escapedInput = escapedInput.Replace(@"\\{", "{");
            escapedInput = escapedInput.Replace(@"\\}", "}");

            return escapedInput;
        }

        #endregion

        #region Updates

        private static void NotifyI18nStateChanges()
        {
            i18nTextSubscriptionsHandler.UpdateStates();
        }

        #endregion
    }
}