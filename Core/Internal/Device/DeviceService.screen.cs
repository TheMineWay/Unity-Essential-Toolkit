using UnityEngine;

namespace EssentialToolkit.Core
{
    /**
     * DeviceService - Screen
     */
    public partial class DeviceService
    {
        // Screens
        public static Display[] GetAllConnectedScreens() => Display.displays;

        // VSync
        public static void SetVSync(VSyncMode vSyncMode) => QualitySettings.vSyncCount = (int)vSyncMode;
        public static VSyncMode GetVSync() => (VSyncMode)QualitySettings.vSyncCount;

        // Refresh rate
        public static void SetTargetFPS(int targetFPS) => Application.targetFrameRate = targetFPS;
        public static int GetTargetFPS() => Application.targetFrameRate;

        // Anti Aliasing
        public static AntiAliasingLevel GetCurrentAntiAliasing() => (AntiAliasingLevel)QualitySettings.antiAliasing;
        public static void SetAntiAliasing(AntiAliasingLevel level) => QualitySettings.antiAliasing = (int)level;

        // Resolution
        public static void SetResolution(int width, int height, bool? fullscreen = null)
        {
            if (fullscreen == null) Screen.SetResolution(width, height, Screen.fullScreen);
            else Screen.SetResolution(width, height, (bool)fullscreen);
        }

        public static void SetResolution(int width, int height, FullScreenMode fullscreenMode) => Screen.SetResolution(width, height, fullscreenMode);

        public static Vector2 GetScreenResolution() => new(Screen.width, Screen.height);

        // Fullscreen
        public static void SetFullscreen(bool fullscreen = true) => Screen.fullScreen = fullscreen;
        public static void SetFullscreen(FullScreenMode mode) => Screen.fullScreenMode = mode;
        public static bool IsFullscreen() => Screen.fullScreen;
        public static FullScreenMode GetFullscreenMode() => Screen.fullScreenMode;

        // Orientation
        public static void SetScreenOrientation(ScreenOrientation orientation) => Screen.orientation = orientation;
    }

    public enum VSyncMode
    {
        DONT_SYNC = 0,
        EVERY_FRAME = 1,
        EVERY_SECOND_FRAME = 2
    }

    public enum AntiAliasingLevel
    {
        OFF = 0,
        X2 = 2,
        X4 = 4,
        X8 = 8
    }
}