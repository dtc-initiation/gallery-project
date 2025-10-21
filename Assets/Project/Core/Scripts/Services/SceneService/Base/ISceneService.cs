using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Services.SceneService.Base {
    public interface ISceneService {
        void InitializeService();
        Awaitable<bool> TryLoadSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource);
        Awaitable StartSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource);
        Awaitable<bool> TryUnloadSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource);
    }
}