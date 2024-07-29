using System;

namespace EssentialToolkit.Dialogs
{
    public class DialogEntry
    {

        public DialogEntry(string text) {
            this.text = text;
        }

        #region Properties
        private string text;
        public string GetText() => text;
        public void SetText(string text) => this.text = text;

        #endregion
    }
}