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

        [SerializeField]
        [Header("If you provide a dialogs JSON file the inspector 'Entries' will be overriden")]
        private TextAsset _jsonDialogEntries;

        private DialogEntry[] _dialogEntries;

        #region Initialization

        private bool _isReady = false;
        public bool IsReady() => _isReady;

        private void Awake()
        {
            StartCoroutine(Initialize());

            I18nService.onLanguageChange += OnLanguageChange;
        }

        private void OnDestroy()
        {
            I18nService.onLanguageChange -= OnLanguageChange;
        }

        private IEnumerator Initialize()
        {
            LoadJsonEntries();

            // Wait for i18n to be initialized
            yield return new WaitUntil(I18nService.SceneAssetsHaveBeenLoaded);

            LoadDialogs();

            // Provider is ready to be used
            _isReady = true;
        }

        private void LoadDialogs()
        {
            var dialogEntries = new List<DialogEntry>();

            foreach (var entry in _entries)
            {
                var text = I18nService.Translate(entry.GetKey(), translation);
                dialogEntries.Add(new DialogEntry(text: text, baseProps: entry));
            }

            _dialogEntries = dialogEntries.ToArray();
        }

        #endregion

        public DialogEntry[] GetEntries() => _dialogEntries;

        #region Language changes

        private void OnLanguageChange()
        {
            LoadDialogs();

            onDialogProviderDataChange.Invoke();
        }

        #endregion

        #region Internal API

        private void LoadJsonEntries()
        {
            if (!_jsonDialogEntries) return;

            _entries = DialogEntry.ParseDialogEntryFromJSON<I18nDialogEntry>(_jsonDialogEntries.text);
        }

        #endregion
    }

    [Serializable]
    public class I18nDialogEntry : ARegisterDialogEntry
    {
        public I18nDialogEntry(string key, string code, string speaker, string[] images) {
            this.key = key;
            base.code = code;
            base.images = images;
            base.speaker = speaker;
        }

        [SerializeField]
        [Header("I18n text key")]
        private string key;

        public string GetKey() => key;
    }
}