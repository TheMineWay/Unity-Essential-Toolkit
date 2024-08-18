using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    internal delegate void DialogManagedControlsEventBus(DialogManagedControlsEventMessages message);
    internal class DialogManagedControls : MonoBehaviour
    {
        public static DialogManagedControlsEventBus eventBus;

        #region API

        public void NextDialog() => eventBus.Invoke(DialogManagedControlsEventMessages.NEXT);

        public void PrevDialog() => eventBus.Invoke(DialogManagedControlsEventMessages.PREV);

        #endregion
    }

    internal enum DialogManagedControlsEventMessages
    {
        NEXT,
        PREV
    }
}