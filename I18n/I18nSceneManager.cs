using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace EssentialToolkit.I18n
{
    [RequireComponent(typeof(I18nManager))]
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
            instance = null;
        }
    }
}
