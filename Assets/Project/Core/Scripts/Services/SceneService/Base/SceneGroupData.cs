using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Core.Scripts.Services.SceneService.Base {
    [Serializable]
    public class SceneGroupData {
        public string sceneGroupName;
        public string activeSceneName;
        public SceneGroupType groupType;
        public bool IsValid() => (!string.IsNullOrEmpty(sceneGroupName) && sceneList.Any());
        public List<SceneData> sceneList = new ();
    }
}