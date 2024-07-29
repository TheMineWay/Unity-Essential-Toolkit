namespace EssentialToolkit.Dialogs
{
    public delegate void OnDialogProviderDataChange();
    public interface IDialogProvider {

        // Whenever origin data changes this event should be invoked
        public OnDialogProviderDataChange onDialogProviderDataChange { get; set; }

        // Initialization status. Will be true when all internal initialization processes ended.
        public bool IsReady();

        // Retrieve all dialog entries
        public DialogEntry[] GetEntries();
    }
}