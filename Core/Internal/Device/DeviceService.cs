using UnityEngine;

namespace EssentialToolkit.Core
{
    public class DeviceService
    {
        #region Platform
        public static Platform platform
        {
            get
            {
#if UNITY_ANDROID || UNITY_IOS
                return Platform.ANDROID;   
#endif
#if UNITY_WEBGL
                return Platform.WEB;
# endif
                return Platform.DESKTOP;
            }
        }

        #endregion
        #region Screen

        public static Vector2 GetScreenResolution() => new Vector2(Screen.width, Screen.height);
        public static Display[] GetAllConnectedScreens() => Display.displays;

        #endregion
    }

    public enum Platform
    {
        DESKTOP,
        MOBILE,
        WEB
    }
}