using UnityEngine;

namespace EssentialToolkit.Core
{
    /**
     * DeviceService - Audio
     */
    public partial class DeviceService
    {
        // Global volume
        public static float GetVolume() => AudioListener.volume;

        public static void SetVolume(float volume) => AudioListener.volume = Mathf.Clamp(volume, 0f, 1f);
    }
}
