using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    public class InspectorDialogProvider : MonoBehaviour, IDialogProvider
    {
        [SerializeField]
        private InspectorDialogEntry[] _entries;

        private DialogEntry[] _dialogEntries;

        private void Awake()
        {
            var dialogEntries = new List<DialogEntry>();

            foreach (var entry in _entries)
            {
                dialogEntries.Add(new DialogEntry(text: entry.text));
            }

            _dialogEntries = dialogEntries.ToArray();
        }

        public DialogEntry[] GetEntries() => _dialogEntries;
    }

    [Serializable]
    public class InspectorDialogEntry
    {
        public string text;
    }
}