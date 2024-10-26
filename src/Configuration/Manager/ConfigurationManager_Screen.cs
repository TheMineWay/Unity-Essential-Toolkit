using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EssentialToolkit.Core;
using System.Linq;

namespace EssentialToolkit.Configuation
{
    public partial class ConfigurationManager : AInitializer {
        #region Props

        [SerializeField]
        [Header("Screen resolution picker")]
        TMP_Dropdown resolutionPicker;

        [SerializeField]
        [Header("Allowed resolution aspect ratios (leave empty to allow all)")]
        Vector2[] allowedAspectRatios;
        private void InitResolutionPicker()
        {
            if (resolutionPicker)
            {
                resolutionPicker.interactable = false;
#if !(UNITY_WEBGL)
                resolutionPicker.ClearOptions();
                // TODO: move options logic to a service/util
                resolutionPicker.AddOptions((from res in ConfigurationService.GetAvailableScreenResolutions() select new TMP_Dropdown.OptionData($"{res.width} x {res.height}")).ToList());

                resolutionPicker.interactable = true;
# endif
            }
        }

        [SerializeField]
        [Header("Display picker")]
        TMP_Dropdown displayPicker;
        private void InitDisplayPicker()
        {
            if (displayPicker)
            {
                displayPicker.interactable = false;

                if (ConfigurationService.SupportsMultipleDisplays())
                {
                    displayPicker.ClearOptions();
                    // TODO: move options logic to a service/util
                    displayPicker.AddOptions((from d in ConfigurationService.GetAvailableDisplays() select new TMP_Dropdown.OptionData(d.GetName())).ToList());

                    displayPicker.interactable = true;
                }
            }
        }

        [SerializeField]
        [Header("Max FPS")]
        Slider maxFps;
        private void InitMaxFps()
        {
            if (maxFps)
            {
                maxFps.interactable = false;
#if !UNITY_WEBGL
                maxFps.interactable = true;
# endif
            }
        }

        [SerializeField]
        [Header("Screen mode")]
        TMP_Dropdown screenMode; // Fullscreen, bordered fullscreen, window
        private void InitScreenMode()
        {
            if (screenMode)
            {
                screenMode.interactable = false;
#if !UNITY_WEBGL
                screenMode.interactable = true;
# endif
            }
        }

        #endregion

        #region Init

        private void InitScreen() {
            InitResolutionPicker();
            InitDisplayPicker();
            InitMaxFps();
            InitScreenMode();
        }

        #endregion
    }
}