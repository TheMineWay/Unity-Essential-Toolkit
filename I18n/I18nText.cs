using System.Collections;
using Unity.VisualScripting;
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

        private void Awake()
        {
            textObject = GetComponent<TextObject>();
            I18nService.GetI18nTextSubscriptionsHandler().AddText(this);
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
            textObject.SetText(I18nService.Translate(key, translationSet));
        }

        #endregion
    }
}