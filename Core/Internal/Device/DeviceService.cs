namespace EssentialToolkit.Core
{
    /**
     * DeviceService - Base
     */
    public partial class DeviceService
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
    }

    public enum Platform
    {
        DESKTOP,
        MOBILE,
        WEB
    }
}