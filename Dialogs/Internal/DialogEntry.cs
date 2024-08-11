namespace EssentialToolkit.Dialogs
{
    public class DialogEntry : ARegisterDialogEntry
    {

        public DialogEntry(ARegisterDialogEntry baseProps, string text)
        {
            this.text = text;
            code = baseProps.GetCode();
            speaker = baseProps.GetSpeaker();
            images = baseProps.GetImages();
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