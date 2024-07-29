using System;

namespace EssentialToolkit.Dialogs
{
    public class DialogEntry
    {

        public DialogEntry(string text, string code = null)
        {
            this.text = text;
            this.code = code;
        }

        #region Properties
        // Text
        private string text;
        public string GetText() => text;
        public void SetText(string text) => this.text = text;

        // Code
        private string code;
        public string GetCode() => code;
        public void SetCode(string code) => this.code = code;
        #endregion
    }
}