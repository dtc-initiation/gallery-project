using System;
using System.Threading;
using ModestTree;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.CoreInstaller {
    public class CoreInitiator : MonoBehaviour{
        ISceneService _sceneLoaderService;

        [Inject]
        private void Setup(ISceneService sceneLoaderService) {
            _sceneLoaderService = sceneLoaderService;
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
            _sceneLoaderService.InitializeService();
        }

        private async Awaitable LoadGameScene(CancellationTokenSource cancellationTokenSource) {
            await _sceneLoaderService.TryLoadSceneGroup("GameScene", cancellationTokenSource);
        }
        
    }
}