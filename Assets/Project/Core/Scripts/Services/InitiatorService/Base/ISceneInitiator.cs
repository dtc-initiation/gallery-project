using System.Threading;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.InitiatorService.Base {
    public interface ISceneInitiator {
        string SceneName { get; }
        Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource);
        Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource);
        Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource);
    }
}