using EssentialToolkit.Core;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Dialogs
{
    public class DialogImagesProvider : AInitializer
    {
        private static Dictionary<string, Sprite> images = new();

        #region Properties

        [SerializeField]
        [Header("Wether the images will be available globally")]
        private bool _isGlobal = false;

        [SerializeField]
        [Header("Image sprites identified by its unique code")]
        private SpriteDictionaryBuilder[] _images;

        #endregion

        #region Initialization & Unload
        public override void Initialize() {
            images = SpriteDictionaryBuilder.Merge(_images, images);
        }

        private void OnDestroy()
        {
            if (_isGlobal) return;

            // Unloads images when the GameObject is unloaded
            Unload();
        }

        #endregion

        #region API

        /**
         * Removes from loaded images those ones provided by this script
         */
        public void Unload()
        {
            foreach (var image in _images)
            {
                RemoveImage(image.GetKey());
            }
        }

        /**
         * Removes all loaded images
         */
        public void UnloadAll() => images.Clear();

        #endregion

        #region Static API

        public static Sprite GetImage(string imageId) => images.ContainsKey(imageId) ? images[imageId] : null;
        public static void AddImage(string imageId, Sprite image) => images.Add(imageId, image);
        public static void RemoveImage(string imageId) => images.Remove(imageId);

        #endregion
    }
}
