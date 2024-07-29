using EssentialToolkit.Core;
using System;
using System.Collections;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    /**
     * The job of this controller is to manage a dialog instance
     */
    public class DialogController : AInitializer
    {
        #region Initialization

        private IDialogProvider _dialogProvider = null;

        public override void Initialize()
        {
            if (initializeComponents != null) return;
            initializeComponents = StartCoroutine(InitializeComponents());
        }

        Coroutine initializeComponents = null;
        private IEnumerator InitializeComponents()
        {
            var dialogProvider = GetComponent<IDialogProvider>();

            if (dialogProvider == null) Debug.LogError("No dialog provider has been provided");

            yield return new WaitUntil(dialogProvider.IsReady);

            dialogProvider.onDialogProviderDataChange += UpdateDialogText;

            _dialogProvider = dialogProvider;
        }

        private void OnDestroy()
        {
            // Remove update event
            _dialogProvider.onDialogProviderDataChange -= UpdateDialogText;
        }

        #endregion

        #region Display UI props

        [SerializeField]
        [Header("Text where dialogs will be displayed")]
        private TextObject dialogTextDisplay;

        #endregion

        #region Dialog state

        private int? currentDialog = null;
        private void SetCurrentDialog(int? currentDialog)
        {
            this.currentDialog = currentDialog;

            // Update UI
            UpdateDialogText();
        }

        #endregion

        #region API

        /**
         * Set current dialog by its code (if not found an Exception is thrown)
         */
        public void SetDialog(string code) => SetDialog(GetEntryIndex(code));

        /**
         * Set dialog by its zero-based index (if not found an Exception is thrown)
         */
        public void SetDialog(int dialogIndex)
        {
            if (dialogIndex < 0 || dialogIndex > GetLastDialogIndex()) throw new Exception("Dialog index out of dialog entries bounds");

            // Update state
            SetCurrentDialog(dialogIndex);
        }

        public DialogEntry GetEntry(int index) => _dialogProvider.GetEntries()[index];
        public DialogEntry GetEntry(string code) => _dialogProvider.GetEntries()[GetEntryIndex(code)];
        public int GetEntryIndex(string code) => Array.FindIndex(_dialogProvider.GetEntries(), (d) => d.GetCode() == code);

        public void NextDialog(int steps = 1)
        {
            if (currentDialog == null) SetDialog(steps - 1);
            else SetDialog((int)currentDialog + steps);
        }
        public void PrevDialog(int steps = 1)
        {
            if (currentDialog == null) SetDialog(steps + 1);
            else SetDialog((int)currentDialog + steps);
        }
        #endregion

        #region Internal API

        private int GetLastDialogIndex() => _dialogProvider.GetEntries().Length - 1;

        private bool IsReady() => _dialogProvider != null;

        private void UpdateDialogText()
        {
            if (currentDialog == null) return;

            dialogTextDisplay.SetText(GetEntry((int)currentDialog).GetText());
        }

        #endregion
    }
}