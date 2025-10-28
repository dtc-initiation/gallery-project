using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Core.Scripts.Services.SceneService.Base {
    [CreateAssetMenu(fileName = "SceneDataCollection", menuName = "Core/Services/SceneDataCollection")]
    public class SceneDataCollection : ScriptableObject, ISceneDataCollection {
        [SerializeField] private List<SceneGroupData> sceneList = new ();

        private Dictionary<string, SceneGroupData> _nameGroupLookup;
        private Dictionary<SceneGroupType, SceneGroupData> _typeGroupLookup;
        
        public List<SceneGroupData> SceneList => sceneList;

        public void InitializeService() {
            InitializeSceneGroupLookup();
        }

        private void InitializeSceneGroupLookup() {
            _nameGroupLookup = new Dictionary<string, SceneGroupData>();
            _typeGroupLookup = new Dictionary<SceneGroupType, SceneGroupData>();
            foreach (var sceneGroupData in sceneList) {
                _nameGroupLookup.Add(sceneGroupData.sceneGroupName, sceneGroupData);
                _typeGroupLookup.Add(sceneGroupData.groupType, sceneGroupData);
            }
        }
        
        public SceneGroupData GetSceneGroupByName(string sceneName) => _nameGroupLookup[sceneName];

        public SceneGroupData GetSceneGroupByType(SceneGroupType groupType) => _typeGroupLookup[groupType];
    }
}