using System.Threading;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.InitiatorService.Base {
    public interface ISceneInitiatorService {
        void RegisterInitator(ISceneInitiator sceneInitiator);
        void UnregisterInitator(ISceneInitiator sceneInitiator);
        Awaitable InvokeLoadEntryPoint(SceneData sceneData, CancellationTokenSource  cancellationTokenSource);
        Awaitable InvokeStartEntryPoint(SceneData sceneData, CancellationTokenSource  cancellationTokenSource);
        Awaitable InvokeUnloadExitPoint(SceneData sceneData, CancellationTokenSource  cancellationTokenSource);
    }
}