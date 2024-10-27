using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EssentialToolkit.Core;
using System.Linq;
using System.Collections.Generic;

namespace EssentialToolkit.Configuation
{
    public partial class ConfigurationManager : AInitializer {
        #region Props

        [SerializeField]
        [Header("Screen resolution picker")]
        TMP_Dropdown resolutionPicker;
        private void InitResolutionPicker()
        {
#if !UNITY_WEBGL
            List<TMP_Dropdown.OptionData> options = GetResolutionPickerDropdownOptions();
            var interactable = true;
#else
            List<TMP_Dropdown.OptionData> options = new();
            var interactable = false;
#endif

            BindDropdown(resolutionPicker, options, OnResolutionSelected, interactable);
        }

        [SerializeField]
        [Header("Display picker")]
        TMP_Dropdown displayPicker;
        private void InitDisplayPicker()
        {
#if !UNITY_WEBGL
            List<TMP_Dropdown.OptionData> options = GetDisplayPickerDropdownOptions();
            var interactable = true;
#else
            List<TMP_Dropdown.OptionData> options = new();
            var interactable = false;
#endif

            BindDropdown(displayPicker, options, OnDisplaySelected, interactable);
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
#if !UNITY_WEBGL
            List<TMP_Dropdown.OptionData> options = GetScreenModeDropdownOptions();
            var interactable = true;
#else
            List<TMP_Dropdown.OptionData> options = new();
            var interactable = false;
#endif

            BindDropdown(screenMode, options, OnScreenModeSelected, interactable);
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

        #region Options generator 

        List<TMP_Dropdown.OptionData> GetResolutionPickerDropdownOptions() => (from res in ConfigurationService.GetAvailableScreenResolutions() select new TMP_Dropdown.OptionData($"{res.width} x {res.height}")).ToList();
        List<TMP_Dropdown.OptionData> GetDisplayPickerDropdownOptions() => (from d in ConfigurationService.GetAvailableDisplays() select new TMP_Dropdown.OptionData(d.GetName())).ToList();
        List<TMP_Dropdown.OptionData> GetScreenModeDropdownOptions() => (from mode in ConfigurationService.GetAvailableScreenModes() select new TMP_Dropdown.OptionData($"{mode} mode")).ToList();

        #endregion

        #region Events

        void OnResolutionSelected(int index)
        {
            var mappedResolutions = (from resolution in ConfigurationService.GetAvailableScreenResolutions() select new Resolution(resolution.width, resolution.height)).ToArray();
            state.resolution = ConfigStateMutator(mappedResolutions, index, ConfigurationState.DEFAULT_RESOLUTION);
        }
        void OnDisplaySelected(int index) {}
        void OnScreenModeSelected(int index) => state.screenMode = ConfigStateMutator(ConfigurationService.GetAvailableScreenModes(), index, ConfigurationState.DEFAULT_SCREENMODE);

        #endregion
    }
}