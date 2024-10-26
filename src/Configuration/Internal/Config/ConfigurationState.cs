using UnityEngine;

namespace EssentialToolkit.Configuation
{
    internal class ConfigurationState
    {
        #region Props

        // Screen
        public Vector2 resolution;
        public FullScreenMode mode = FullScreenMode.FullScreenWindow;
        public int maxFps;

        #endregion

        internal void Apply() {
#if UNITY_EDITOR
            Debug.Log("[CONFIG]: start apply");
#endif

            // Screen
            Application.targetFrameRate = maxFps;
            Screen.SetResolution((int)resolution.x, (int)resolution.y, Screen.fullScreen);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}