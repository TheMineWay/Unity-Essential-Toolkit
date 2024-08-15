using EssentialToolkit.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EssentialToolkit.Dialogs
{
    public class DialogImagesDisplay : AInitializer
    {
        #region Displayer instances

        private static Dictionary<string, DialogImagesDisplay> imageDisplayers = new();
        private static DialogImagesDisplay defaultDisplayer = null;

        #endregion

        #region Properties

        [SerializeField]
        [Header("Leave empty to be the default one")]
        private string displayId = "";

        [SerializeField]
        private Image _imageDisplay;

        #endregion

        #region Initialization

        public override void Initialize()
        {
#if UNITY_EDITOR
            if (displayId != "" && displayId.Trim() == "") Debug.LogWarning("Detected a displayId containing only spaces. This might be a developer error. If it is not, please, do not use only spaces to identify a DialogImagesDisplay (or any other component)");
# endif

            if (displayId == "") defaultDisplayer = this;
            else imageDisplayers.Add(displayId, this);
        }

        #endregion

        #region API

        public void DisplayImage(string imageId)
        {
            var image = DialogImagesProvider.GetImage(imageId);

            _imageDisplay.sprite = image;
        }

        #endregion

        #region Static API

        public static DialogImagesDisplay GetImagesDisplay(string displayerId)
        {
            if (!imageDisplayers.ContainsKey(displayerId)) return defaultDisplayer;

            return imageDisplayers[displayerId];
        }

        public static void DisplayImage(string imageId, string target)
        {
            var displayer = GetImagesDisplay(target);
            if (displayer == null) return;

            displayer.DisplayImage(imageId);
        }

        public static void DisplayImages(ARegisterDialogEntry.Image[] images)
        {
            foreach (var image in images)
            {
                DisplayImage(image.image, image.target);
            }
        }

        #endregion
    }
}