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

        private void Awake()
        {
            textObject = GetComponent<TextObject>();
            I18nService.GetI18nTextSubscriptionsHandler().AddText(this);
        }

        #region Key access

        public void SetKey(string key, bool update = true) => this.key = key;
        public string GetKey() => key;

        #endregion

        #region Translation
        
        public void LoadKeyText()
        {

        }

        #endregion
    }
}