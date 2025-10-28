using System.Collections.Generic;

namespace Project.Core.Scripts.Services.SceneService.Base {
    public interface ISceneDataCollection {
        List<SceneGroupData> SceneList { get; }
        SceneGroupData GetSceneGroupByName(string sceneName);
        SceneGroupData GetSceneGroupByType(SceneGroupType groupType);
        
    }
}