using System.Threading;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.States {
    public class GamePlayState : BaseApplicationState {
        private readonly ISceneService _sceneLoaderService;
        
        public override ApplicationStateType ApplicationStateType => ApplicationStateType.GamePlay;
        public override SceneGroupType SceneGroupType => SceneGroupType.GamePlay;

        public GamePlayState(ISceneService sceneLoaderService) {
            _sceneLoaderService = sceneLoaderService;
        }

        public override async Awaitable LoadState(CancellationTokenSource cancellationTokenSource) {
            await base.LoadState(cancellationTokenSource);
            await _sceneLoaderService.TryLoadSceneGroup(SceneGroupType, cancellationTokenSource);
        }

        public override async Awaitable ExitState(CancellationTokenSource cancellationTokenSource) {
            await base.ExitState(cancellationTokenSource);
            await _sceneLoaderService.TryUnloadSceneGroup(SceneGroupType, cancellationTokenSource);
        }

        public class Factory : PlaceholderFactory<GamePlayState> { }
        
    }
}