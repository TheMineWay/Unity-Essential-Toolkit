using EssentialToolkit.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EssentialToolkit.Configuation
{
    public partial class ConfigurationManager : AInitializer {
        #region Props
        [SerializeField]
        [Header("Apply configuration button")]
        Button apply;
        #endregion

        #region State
        ConfigurationState state;
        #endregion

        public override void Initialize() => StartCoroutine(WaitForInitialization());

        IEnumerator WaitForInitialization()
        {
            yield return new WaitUntil(() => ConfigurationInitializer.Instance != null);

            InitScreen();

            state = ConfigurationService.ReadConfiguration() ?? new();
            apply?.onClick.AddListener(OnApply);
        }

        void OnApply() {
            state.Apply();
        }

        private void OnDestroy()
        {
            apply?.onClick.RemoveListener(OnApply);
        }
    }
}