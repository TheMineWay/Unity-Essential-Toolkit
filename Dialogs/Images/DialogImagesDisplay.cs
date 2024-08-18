using EssentialToolkit.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
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

        #region State

        private string currentImageId = null;
        public string GetCurrentImageId() => currentImageId;
        private void SetImage(Sprite image, string imageId)
        {
            // If the image has not changed, state remains the same
            if (currentImageId == imageId) return;

            // Update current state
            currentImageId = imageId;

            // Update image
            _imageDisplay.sprite = image;

            onImageChange.Invoke();
        }

        #endregion

        #region Events

        [SerializeField]
        [Header("Whenever this displayer renders an image")]
        private UnityEvent onImageChange;

        #endregion

        #region Initialization

        public override void Initialize()
        {
#if UNITY_EDITOR
            if (displayId != "" && displayId.Trim() == "") Debug.LogWarning("Detected a displayId containing only spaces. This might be a developer error. If it is not, please, do not use only spaces to identify a DialogImagesDisplay (or any other component)");

            if (displayId == "" && defaultDisplayer != null) Debug.LogWarning("There is already a default dialog image displayer but you have registered another one. This might have been caused because you have two or more DialogImagesDisplay scripts present in your scene with no displayId value.");
            if (imageDisplayers.Keys.Contains(displayId)) Debug.LogWarning($"There is already a DialogImagesDisplay registered with the id \"{displayId}\" but two or more have been registered. This can be caused because you repeated ids. Check that all have unique ids.");
# endif

            if (displayId == "") defaultDisplayer = this;
            else imageDisplayers.Add(displayId, this);
        }

        private void OnDestroy()
        {
            imageDisplayers.Remove(displayId);
        }

        #endregion

        #region API

        public void DisplayImage(string imageId)
        {
            if (imageId == null)
            {
                SetImage(null, null);
                return;
            }

            var image = DialogImagesProvider.GetImage(imageId);

            SetImage(image, imageId);
        }

        public void Clear() => DisplayImage(null);

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

        public static void DisplayImages(ARegisterDialogEntry.Image[] images, bool cleanup = true)
        {
            // If cleanup is enabled, not specified displayers will reset its image
            if (cleanup)
            {
                var targets = from image in images select image.target;

                // Pick only targets that are not in use by this method call
                var toClean = from displayer in GetAllDisplayers() where !targets.Contains(displayer.displayId) select displayer;

                foreach (var target in toClean)
                {
                    target.Clear();
                }
            }

            // Begin display
            foreach (var image in images)
            {
                DisplayImage(image.image, image.target);
            }
        }

        public static DialogImagesDisplay[] GetAllDisplayers() => new DialogImagesDisplay[] { defaultDisplayer }.Concat(imageDisplayers.Values).ToArray();
        #endregion
    }
}