using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    public class InspectorDialogProvider : MonoBehaviour, IDialogProvider
    {
        public OnDialogProviderDataChange onDialogProviderDataChange { get; set; }

        [SerializeField]
        private InspectorDialogEntry[] _entries;

        private DialogEntry[] _dialogEntries;

        #region Initialization

        private bool _isReady = false;
        public bool IsReady() => _isReady;

        private void Awake()
        {
            var dialogEntries = new List<DialogEntry>();

            foreach (var entry in _entries)
            {
                dialogEntries.Add(new DialogEntry(text: entry.GetText(), code: entry.GetCode()));
            }

            _dialogEntries = dialogEntries.ToArray();

            // Provider is ready to be used
            _isReady = true;
        }

        #endregion

        public DialogEntry[] GetEntries() => _dialogEntries;
    }

    [Serializable]
    public class InspectorDialogEntry
    {
        
        [SerializeField]
        [Header("Text to display")]
        private string text;

        public string GetText() => text;

        [SerializeField]
        [Header("Unique dialog entry identifier")]
        private string code;
        public string GetCode() => code.Trim() == "" ? null : code;
    }
}