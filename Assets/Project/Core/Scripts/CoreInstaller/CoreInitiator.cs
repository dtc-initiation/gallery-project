using System;
using System.Threading;
using ModestTree;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.CoreInstaller {
    public class CoreInitiator : MonoBehaviour {
        private ISceneService _sceneLoaderService;
        private SceneDataCollection _sceneDataCollection;

        [Inject]
        private void Setup(ISceneService sceneLoaderService, SceneDataCollection sceneDataCollection) {
            _sceneLoaderService = sceneLoaderService;
            _sceneDataCollection = sceneDataCollection;
        }

        private void Start() {
            _ = InitEntryPoint(CancellationTokenSource.CreateLinkedTokenSource(Application.exitCancellationToken));
        }

        private async Awaitable InitEntryPoint(CancellationTokenSource cancellationTokenSource) {
            // TODO loading screen show
            try {
                InitializeServices();
                await LoadGameScene(cancellationTokenSource);
            } catch (Exception e) {
                LogService.LogError(e.Message);
                throw;
            }
            // TODO loading screen hide
        }

        private void InitializeServices() {
            _sceneDataCollection.InitializeService();
            _sceneLoaderService.InitializeService();
        }

        private async Awaitable LoadGameScene(CancellationTokenSource cancellationTokenSource) {
            await _sceneLoaderService.TryLoadSceneGroup(SceneGroupType.Game, cancellationTokenSource);
        }
        
    }
}