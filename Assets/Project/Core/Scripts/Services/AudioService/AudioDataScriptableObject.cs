using System;
using Project.Core.Scripts.Services.AudioService.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.AudioService {
    [CreateAssetMenu(fileName = "AudioDataScriptableObject", menuName = "Core/Services/Audio/AudioDataScriptableObject")]
    public class AudioDataScriptableObject : ScriptableObject {
        [SerializeField] public AudioData[] AudioDatas;
    }
}