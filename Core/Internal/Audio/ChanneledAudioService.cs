using System.Collections.Generic;

namespace EssentialToolkit.Core
{
    public delegate void OnChanneledAudioSettingsChange(AudioChannels audioChannel, float newVolume);
    public class ChanneledAudioService
    {
        #region Events
        public static OnChanneledAudioSettingsChange onChanneledAudioSettingsChange;

        #endregion

        #region Settings
        private static Dictionary<AudioChannels, float> _channeledAudioSettings = new();

        public static void SetAudioChannelVolume(AudioChannels audioChannel, float newVolume)
        {
            // Update in-memory volume settings
            _channeledAudioSettings[audioChannel] = newVolume;

            // Call all listeners
            onChanneledAudioSettingsChange.Invoke(audioChannel, newVolume);
        }

        public static float GetVolumeByAudioChannel(AudioChannels audioChannel) => _channeledAudioSettings[audioChannel];

        #endregion
    }
}
