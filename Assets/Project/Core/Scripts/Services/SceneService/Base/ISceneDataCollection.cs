using System.Collections.Generic;

namespace Project.Core.Scripts.Services.SceneService.Base {
    public interface ISceneDataCollection {
        List<SceneGroupData> SceneList { get; }
    }
}