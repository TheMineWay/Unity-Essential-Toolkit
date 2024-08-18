using System.Collections.Generic;
using System.Linq;

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

        public static float GetVolumeByAudioChannel(AudioChannels audioChannel) {
            if (!_channeledAudioSettings.ContainsKey(audioChannel)) return 0;

            return _channeledAudioSettings[audioChannel];
        }

        public static AudioChannels[] GetAllAudioChannels() => _channeledAudioSettings.Keys.ToArray();

        #endregion
    }
}
