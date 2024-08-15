using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    public abstract class ARegisterDialogEntry
    {
        #region Code 
        // Represents the code of the dialog
        [SerializeField]
        [Header("Unique dialog entry identifier")]
        protected string code;
        public string GetCode() => code.Trim() == "" ? null : code;
        public void SetCode(string code) => this.code = code;

        #endregion

        #region Speaker

        // Represents who is speaking
        [SerializeField]
        protected string speaker;
        public string GetSpeaker() => speaker?.Trim() == "" ? null : speaker;
        public void SetSpeaker(string speaker) => this.speaker = speaker;

        #endregion

        #region Images

        // Represents images to display (by image code)
        [SerializeField]
        [Header("Image codes to be displayed along with this dialog")]
        protected Image[] images;

        public Image[] GetImages() => images;
        public void SetImages(Image[] images) => this.images = images;

        #endregion

        #region Lock

        // Represents if the dialog locks the dialog skip
        [SerializeField]
        [Header("Wether the dialog is skippable using NextDialog, PrevDialog or MoveDialog")]
        protected bool locked;

        public bool IsLocked() => locked;
        public void SetLocked(bool locked) => this.locked = locked;

        #endregion

        public class Image
        {
            public string image;
            public string target;
        }
    }
}