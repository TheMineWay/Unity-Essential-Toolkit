using EssentialToolkit.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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

        #region Utils

        void BindDropdown(TMP_Dropdown dropdown, List<TMP_Dropdown.OptionData> options, UnityAction<int> onChange, bool defaultInteractable = true) {
            if (dropdown == null) return;

            dropdown.onValueChanged.RemoveListener(onChange);
            dropdown.interactable = false;
            dropdown.ClearOptions();

            dropdown.options = options;

            dropdown.onValueChanged.AddListener(onChange);
            dropdown.interactable = defaultInteractable;
        }

        T ConfigStateMutator<T>(T[] values, int index, T fallback = default) {
            if (index >= values.Length) return fallback;
            return values[index];
        }

        #endregion
    }
}