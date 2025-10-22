using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.Scripts.Services.SceneService.Base {
    [CreateAssetMenu(fileName = "SceneDataCollection", menuName = "SceneDataCollection")]
    public class SceneDataCollection : ScriptableObject, ISceneDataCollection{
        [SerializeField] private List<SceneGroupData> sceneList = new ();
        public List<SceneGroupData> SceneList => sceneList;
        
    }
}