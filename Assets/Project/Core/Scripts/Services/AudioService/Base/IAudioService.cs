namespace Project.Core.Scripts.Services.AudioService.Base {
    public interface IAudioService {
        void InitEntryPoint();
        void PlayAudio(AudioChannel audioChannel, AudioPlayType audioPlayType, string audioName);
        void AddAudio(AudioDataScriptableObject audioScriptableObject);
    }
}