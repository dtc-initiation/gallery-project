using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Core.Scripts.Services.SceneService.Base {
    public interface ISceneService {
        void InitializeService();
        Awaitable<bool> TryLoadSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource);
        Awaitable StartSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource);
        Awaitable<bool> TryUnloadSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource);
    }
}