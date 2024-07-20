using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.I18n
{
    [RequireComponent(typeof(TextObject))]
    public class I18nText : MonoBehaviour
    {
        private TextObject textObject;

        // Properties
        [Header("Translation key")]
        [SerializeField]
        private string key;
        [SerializeField]
        private TranslationSets translationSet;

        // Replacements
        [Header("Initial replacement values")]
        [SerializeField]
        private I18nTextReplacementPair[] initialReplacements;

        private void Awake()
        {
            textObject = GetComponent<TextObject>();
            I18nService.GetI18nTextSubscriptionsHandler().AddText(this);

            LoadInitialReplacements();
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(I18nService.SceneAssetsHaveBeenLoaded);

            // Display text from translation
            LoadKeyText();
        }

        #region Key access

        public void SetKey(string key, bool update = true) => this.key = key;
        public string GetKey() => key;

        #endregion

        #region Translation
        
        public void LoadKeyText()
        {
            textObject.SetText(I18nService.Translate(key, translationSet, _replacements));
        }

        #endregion

        #region Replacements

        private Dictionary<string, string> _replacements = new();
        private void OnReplacementsUpdate()
        {
            LoadKeyText();
        }

        public void SetReplacement(string key, string value, bool invokeUpdatedEvent = true)
        {
            _replacements[key] = value;

            if (invokeUpdatedEvent) OnReplacementsUpdate();
        }

        public void RemoveReplacement(string key, bool invokeUpdatedEvent = true)
        {
            if (!_replacements.ContainsKey(key)) return;

            _replacements.Remove(key);
            if (invokeUpdatedEvent) OnReplacementsUpdate();
        }

        /**
         * Only called on startup
         */
        private void LoadInitialReplacements()
        {
            foreach (var replacement in initialReplacements)
            {
                _replacements[replacement.key] = replacement.value;
            }
        }

        #endregion
    }

    [Serializable]
    class I18nTextReplacementPair
    {
        public string key;
        public string value;
    }
}