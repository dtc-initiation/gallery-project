using System;
using UnityEngine;

namespace Project.Core.Scripts.Services.AudioService.Base {
    [Serializable]
    public struct AudioData {
        public string AudioName;
        public AudioChannel AudioChannel;
        public AudioClip AudioClip;
    }
}