using EssentialToolkit.I18n;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    public class I18nDialogProvider : MonoBehaviour, IDialogProvider
    {
        public OnDialogProviderDataChange onDialogProviderDataChange { get; set; }

        [SerializeField]
        private TranslationSets translation;

        [SerializeField]
        private I18nDialogEntry[] _entries;

        private DialogEntry[] _dialogEntries;

        #region Initialization

        private bool _isReady = false;
        public bool IsReady() => _isReady;

        private void Awake()
        {
            StartCoroutine(Initialize());
        }

        private IEnumerator Initialize()
        {
            // Wait for i18n to be initialized
            yield return new WaitUntil(I18nService.SceneAssetsHaveBeenLoaded);

            var dialogEntries = new List<DialogEntry>();

            foreach (var entry in _entries)
            {
                var text = I18nService.Translate(entry.GetKey(), translation);
                dialogEntries.Add(new DialogEntry(text: text, code: entry.GetCode()));
            }

            _dialogEntries = dialogEntries.ToArray();

            // Provider is ready to be used
            _isReady = true;
        }

        #endregion

        public DialogEntry[] GetEntries() => _dialogEntries;
    }

    [Serializable]
    public class I18nDialogEntry
    {

        [SerializeField]
        [Header("I18n text key")]
        private string key;

        public string GetKey() => key;

        [SerializeField]
        [Header("Unique dialog entry identifier")]
        private string code;
        public string GetCode() => code.Trim() == "" ? null : code;
    }
}