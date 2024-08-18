using UnityEngine;

namespace EssentialToolkit.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class ChanneledAudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioChannels _audioChannel;

        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            // Register change event
            ChanneledAudioService.onChanneledAudioSettingsChange += OnChanneledAudioServiceTriggersChangeEvent;

            // Set initial volume
            SetVolume(ChanneledAudioService.GetVolumeByAudioChannel(_audioChannel));
        }

        private void OnChanneledAudioServiceTriggersChangeEvent(AudioChannels channel, float newVolume)
        {
            if (_audioChannel != channel) return;

            SetVolume(newVolume);
        }

        #region API

        public void SetVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        #endregion

        private void OnDestroy()
        {
            ChanneledAudioService.onChanneledAudioSettingsChange -= OnChanneledAudioServiceTriggersChangeEvent;
        }
    }
}
