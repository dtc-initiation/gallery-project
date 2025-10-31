using System;
using System.Collections.Generic;
using Project.Core.Scripts.Services.AudioService.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.AudioService {
    [CreateAssetMenu(fileName = "AudioDataScriptableObject", menuName = "Core/Services/Audio/AudioDataScriptableObject")]
    public class AudioDataScriptableObject : ScriptableObject {
        [SerializeField] public List<AudioData> AudioDatas = new ();
    }
}