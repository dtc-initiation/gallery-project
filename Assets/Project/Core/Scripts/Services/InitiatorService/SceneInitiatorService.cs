using System.Collections.Generic;
using System.Threading;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.InitiatorService {
    public class SceneInitiatorService : ISceneInitiatorService{
        private readonly Dictionary<string, ISceneInitiator> _sceneInitiators = new Dictionary<string, ISceneInitiator>();
        
        public void RegisterInitator(ISceneInitiator sceneInitiator) {
            _sceneInitiators.Add(sceneInitiator.SceneData.SceneName, sceneInitiator);
        }

        public void UnregisterInitator(ISceneInitiator sceneInitiator) {
            _sceneInitiators.Remove(sceneInitiator.SceneData.SceneName);
        }

        public async Awaitable InvokeLoadEntryPoint(SceneData sceneData, CancellationTokenSource cancellationTokenSource) {
            await _sceneInitiators[sceneData.SceneName].LoadEntryPoint(cancellationTokenSource);
        }

        public async Awaitable InvokeStartEntryPoint(SceneData sceneData, CancellationTokenSource cancellationTokenSource) {
            await _sceneInitiators[sceneData.SceneName].StartEntryPoint(cancellationTokenSource);
        }

        public async Awaitable InvokeUnloadExitPoint(SceneData sceneData, CancellationTokenSource cancellationTokenSource) {
            await _sceneInitiators[sceneData.SceneName].UnloadExitPoint(cancellationTokenSource);
        }
    }
}