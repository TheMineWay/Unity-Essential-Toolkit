using EssentialToolkit.Core;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    /**
     * The job of this controller is to manage a dialog
     */
    public class DialogController : AInitializer
    {
        #region Initialization

        private IDialogProvider _dialogProvider;

        public override void Initialize()
        {
            _dialogProvider = GetComponent<IDialogProvider>();

            if (_dialogProvider == null) Debug.LogError("No dialog provider has been provided");
        }

        #endregion
    }
}