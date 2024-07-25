namespace EssentialToolkit.Core
{
    public class DeviceService
    {
        public static Platform platform {
            get {
#if UNITY_ANDROID || UNITY_IOS
                return Platform.ANDROID;   
#endif
#if UNITY_WEBGL
                return Platform.WEB;
# endif
                return Platform.DESKTOP;
            }
        }
    }

    public enum Platform
    {
        DESKTOP,
        MOBILE,
        WEB
    }
}