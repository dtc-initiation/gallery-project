using System.Collections.Generic;
using Project.Core.Scripts.Services.AudioService.Base;
using Project.Core.Scripts.Services.Logger.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.AudioService {
    public class AudioService : MonoBehaviour, IAudioService {
        [SerializeField] private AudioSource masterAudioSource;
        [SerializeField] private AudioSource fxAudioSource;
        [SerializeField] private AudioSource musicAudioSource;

        private Dictionary<AudioChannel, Dictionary<string, AudioClip>> _audioLookup = new();
        private Dictionary<AudioChannel, AudioSource> _audioSourceLookup = new();

        public void InitializeService() {
            _audioSourceLookup.Add(AudioChannel.Master, masterAudioSource);
            _audioSourceLookup.Add(AudioChannel.Fx, fxAudioSource);
            _audioSourceLookup.Add(AudioChannel.Music, musicAudioSource);
        }
        
        public void PlayAudio(AudioChannel audioChannel, AudioPlayType audioPlayType, string audioName) {
            TryPlayAudio(audioChannel, audioPlayType, audioName, out _);
        }

        private bool TryPlayAudio(AudioChannel audioChannel, AudioPlayType audioPlayType, string audioName, out AudioClip audioClip) {
            audioClip = null;

            var audioSource = _audioSourceLookup.GetValueOrDefault(audioChannel);
            if (audioSource == null) {
                LogService.LogError($"No audio source for {audioChannel} found.");
                return false;
            }
            
            var audioChannelLookup = GetOrAddChannelLookup(audioChannel);
            var audio = audioChannelLookup.GetValueOrDefault(audioName);
            if (audio == null) {
                LogService.LogError($"No audio for {audioName} in {audioChannel} found.");
                return false;
            }
            
            switch (audioPlayType) {
                case  AudioPlayType.OneShot:
                    audioSource.loop = false;
                    audioSource.PlayOneShot(audioClip);
                    break;
                case  AudioPlayType.Loop:
                    audioSource.clip = audio;
                    audioSource.loop = true;
                    audioSource.Play();
                    break;
            }
            LogService.LogTopic($"Played Audio {audioName} for channel {audioChannel}", LogTopic.Audio);
            return true;
        }

        public void AddAudio(AudioDataScriptableObject audioScriptableObject) {
            foreach (var audioData in audioScriptableObject.AudioDatas) {
                var audioChannel = GetOrAddChannelLookup(audioData.AudioChannel);
                audioChannel.Add(audioData.AudioName, audioData.AudioClip);
            }
        }

        private Dictionary<string, AudioClip> GetOrAddChannelLookup(AudioChannel audioChannel) {
            var audioChannelLookup = _audioLookup.GetValueOrDefault(audioChannel);
            if (audioChannelLookup == null) {
                audioChannelLookup = new Dictionary<string, AudioClip>();
                _audioLookup.Add(audioChannel, audioChannelLookup);
            }
            return audioChannelLookup;
        }
        
    }
}