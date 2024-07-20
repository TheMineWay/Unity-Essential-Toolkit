using System.Collections;
using UnityEngine;

namespace EssentialToolkit.I18n
{
    public class I18nSceneManager : MonoBehaviour
    {
        #region Self instance

        private static I18nSceneManager instance = null;
        public static I18nSceneManager GetInstance() => instance;

        #endregion

        [Header("Translations available in this scene")]
        [SerializeField]
        private TranslationSets[] _sceneSets;

        [Header("Initialize scene translations on load")]
        [SerializeField]
        private bool _loadOnStartup = true;

        #region Initialization

        public void Initialize()
        {
            I18nService.LoadTranslations(_sceneSets);
        }

        #endregion

        #region Managers

        public void SetLanguage(Language language)
        {
            I18nService.SetLanguage(language);
        }

        public void SetLanguage(int languageIndex)
        {
            SetLanguage((Language)languageIndex);
        }

        #endregion

        private void Awake()
        {
            // Load current instance in memory
            instance = this;

            StartCoroutine(AwakeEnumerator());
        }
        private IEnumerator AwakeEnumerator()
        {
            yield return new WaitUntil(I18nService.AssetsHaveBeenLoaded);

            // Once we are sure assets have been initialized

            if (_loadOnStartup) Initialize();
        }

        private void OnDestroy()
        {
            I18nService.GetI18nTextSubscriptionsHandler().Clear();
            instance = null;
        }
    }
}
