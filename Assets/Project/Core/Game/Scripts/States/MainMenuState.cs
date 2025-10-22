using System.Threading;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.SceneService;
using Project.Core.Scripts.Services.SceneService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.States {
    public class MainMenuState : BaseApplicationState {
        private readonly SceneLoaderService  _sceneLoaderService;
        public override ApplicationStateType ApplicationStateType => ApplicationStateType.MainMenu;

        public override async Awaitable LoadState(CancellationTokenSource cancellationTokenSource) {
            await base.LoadState(cancellationTokenSource);
            await _sceneLoaderService.TryLoadSceneGroup("MainMenu", cancellationTokenSource);
        }

        public override async Awaitable ExitState(CancellationTokenSource cancellationTokenSource) {
            await base.ExitState(cancellationTokenSource);
            await _sceneLoaderService.TryUnloadSceneGroup("MainMenu", cancellationTokenSource);
        }
        
        public class Factory : PlaceholderFactory<MainMenuState> {}
        
    }
}