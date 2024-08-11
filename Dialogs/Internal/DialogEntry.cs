namespace EssentialToolkit.Dialogs
{
    public class DialogEntry : ARegisterDialogEntry
    {

        public DialogEntry(string text, string code = null)
        {
            this.text = text;
            base.code = code;
        }

        #region Properties
        // Text
        private string text;
        public string GetText() => text;
        public void SetText(string text) => this.text = text;
        #endregion

        #region API

        public bool HasSpeaker() => GetSpeaker() != null;

        #endregion
    }
}