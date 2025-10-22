using System.Threading;
using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInitiator : ISceneInitiator, IGameInitiator{
        private readonly ISceneInitiatorService _sceneInitiator;
        private readonly MainMenuState.Factory _mainMenuStateFactory;
        private readonly IApplicationStateService _applicationStateMachine;
        private const string _sceneName = "GameScene";
        
        public string SceneName => _sceneName;

        [Inject]
        public GameInitiator(IApplicationStateService stateMachine, MainMenuState.Factory mainMenuStateFactory, ISceneInitiatorService sceneInitiator) {
            _applicationStateMachine = stateMachine;
            _mainMenuStateFactory = mainMenuStateFactory;
            _sceneInitiator = sceneInitiator;
            _sceneInitiator.RegisterInitator(this);
        }
        
        public async Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            // TODO loading screen slider
            await _applicationStateMachine.EnterInitialGameState(_mainMenuStateFactory.Create(), cancellationTokenSource);
        }

        public Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            _sceneInitiator.UnregisterInitator(this);
            return AwaitableUtils.CompletedTask;
        }
    }
}