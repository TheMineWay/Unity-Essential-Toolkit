using UnityEngine;

namespace EssentialToolkit.Configuation
{
    internal class ConfigurationState
    {
        #region Default values

        public static readonly Resolution DEFAULT_RESOLUTION = null;
        public static readonly FullScreenMode DEFAULT_SCREENMODE = FullScreenMode.FullScreenWindow;
        public static readonly int DEFAULT_MAX_FPS = -1;

        #endregion

        #region Props

        // Screen
        public Resolution resolution = DEFAULT_RESOLUTION;
        public FullScreenMode screenMode = DEFAULT_SCREENMODE;
        public int maxFps = DEFAULT_MAX_FPS;

        #endregion

        internal void Apply() {
#if UNITY_EDITOR
            Debug.Log("[CONFIG]: start apply");
#endif

            // Screen configs
            Application.targetFrameRate = maxFps;
            Screen.SetResolution(resolution != null ? resolution.width : Screen.currentResolution.width, resolution != null ? resolution.height : Screen.currentResolution.height, Screen.fullScreen);
            Screen.fullScreenMode = screenMode;

            // Save
            ConfigurationService.WriteConfiguration(this);
        }
    }
}