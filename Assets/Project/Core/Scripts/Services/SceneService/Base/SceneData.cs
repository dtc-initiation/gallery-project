using System;
using Eflatun.SceneReference;
using UnityEngine;

namespace Project.Core.Scripts.Services.SceneService.Base {
    [Serializable]
    public class SceneData {
        public SceneReference sceneReference;
        public string SceneName => sceneReference.Name;
        public string ScenePath => sceneReference.Path;
    }
    
}