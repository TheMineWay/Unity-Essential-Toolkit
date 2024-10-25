using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EssentialToolkit.Core;

namespace EssentialToolkit.Configuation
{
    public partial class ConfigurationManager : AInitializer {
        #region Props

        [SerializeField]
        [Header("Screen resolution picker")]
        TMP_Dropdown resolution;
        private void _InitResolution()
        {
            if (resolution)
            {
#if UNITY_WEBGL
                resolution.interactable = false;
#else
                resolution.interactable = true;
# endif
            }
        }

        [SerializeField]
        [Header("Screen picker")]
        TMP_Dropdown screenPicker;
        private void _InitScreenPicker()
        {
            if (screenPicker)
            {
#if UNITY_WEBGL
                screenPicker.interactable = false;
#else
                screenPicker.interactable = true;
# endif
            }
        }

        [SerializeField]
        [Header("Max FPS")]
        Slider maxFps;
        private void _InitMaxFps()
        {
            if (maxFps)
            {
#if UNITY_WEBGL
                maxFps.interactable = false;
#else
                maxFps.interactable = true;
# endif
            }
        }

        [SerializeField]
        [Header("Screen mode")]
        TMP_Dropdown screenMode; // Fullscreen, bordered fullscreen, window
        private void _InitScreenMode()
        {
            if (screenMode)
            {
#if UNITY_WEBGL
                screenMode.interactable = false;
#else
                screenMode.interactable = true;
# endif
            }
        }

        #endregion

        #region Init

        private void InitScreen() {
            _InitResolution();
            _InitScreenPicker();
            _InitMaxFps();
            _InitScreenMode();
        }

        #endregion
    }
}