using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    public class SimpleDialogProvider : MonoBehaviour, IDialogProvider
    {
        public OnDialogProviderDataChange onDialogProviderDataChange { get; set; }

        [SerializeField]
        private SimpleDialogEntry[] _entries;

        [SerializeField]
        [Header("If you provide a dialogs JSON file the inspector 'Entries' will be overriden")]
        private TextAsset _jsonDialogEntries;

        private DialogEntry[] _dialogEntries;

        #region Initialization

        private bool _isReady = false;
        public bool IsReady() => _isReady;

        private void Awake()
        {
            LoadJsonEntries();

            var dialogEntries = new List<DialogEntry>();

            foreach (var entry in _entries)
            {
                dialogEntries.Add(new DialogEntry(text: entry.GetText(), baseProps: entry));
            }

            _dialogEntries = dialogEntries.ToArray();

            // Provider is ready to be used
            _isReady = true;
        }

        #endregion

        public DialogEntry[] GetEntries() => _dialogEntries;

        #region Internal API

        private void LoadJsonEntries()
        {
            if (!_jsonDialogEntries) return;

            _entries = DialogEntry.ParseDialogEntryFromJSON<SimpleDialogEntry>(_jsonDialogEntries.text);
        }

        #endregion
    }

    [Serializable]
    public class SimpleDialogEntry : ARegisterDialogEntry
    {
        public SimpleDialogEntry(string text, string code, string speaker, Image[] images, bool locked, string[] events)
        {
            this.text = text;
            base.code = code;
            base.images = images;
            base.speaker = speaker;
            base.locked = locked;
            base.events = events;
        }

        [SerializeField]
        [Header("Text to display")]
        private string text;

        public string GetText() => text;
        public void SetText(string text) => this.text = text;
    }
}