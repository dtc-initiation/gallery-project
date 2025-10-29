using System.Threading;
using Project.Core.Game.Scripts.Mvc.CameraSystem.PixelCamera;
using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Services.ApplicationStateMachine;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using Project.Core.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.GameInitiator {
    public class GameInitiator : ISceneInitiator, IGameInitiator {
        private readonly ISceneInitiatorService _sceneInitiator;
        private readonly IApplicationStateService _applicationStateMachine;
        private readonly InitialStateConfig _initialStateConfig;
        private readonly LobbyState.Factory _lobbyStateFactory;
        private readonly GamePlayState.Factory _gamePlayStateFactory;
        private readonly IPixelCameraController _pixelCameraController;

        public string SceneName => "GameScene";


        [Inject]
        public GameInitiator(
            IApplicationStateService stateMachine,
            ISceneInitiatorService sceneInitiator,
            InitialStateConfig initialStateConfig,
            LobbyState.Factory lobbyStateFactory,
            GamePlayState.Factory gamePlayStateFactory,
            IPixelCameraController pixelCameraController
        ) {
            _applicationStateMachine = stateMachine;
            _sceneInitiator = sceneInitiator;
            _initialStateConfig = initialStateConfig;
            _lobbyStateFactory = lobbyStateFactory;
            _gamePlayStateFactory = gamePlayStateFactory;
            _pixelCameraController = pixelCameraController;
            _sceneInitiator.RegisterInitator(this);
        }


        public Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            IApplicationState initialState = ResolveInitialState();
            _applicationStateMachine.EnterInitialGameState(initialState, cancellationTokenSource);
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            _pixelCameraController.InitializeEntry();
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            _sceneInitiator.UnregisterInitator(this);
            return AwaitableUtils.CompletedTask;
        }

        private IApplicationState ResolveInitialState() {
            return _initialStateConfig.initialStateType switch {
                ApplicationStateType.Lobby => _lobbyStateFactory.Create(),
                ApplicationStateType.GamePlay => _gamePlayStateFactory.Create(),
                _ => _lobbyStateFactory.Create()
            };
        }

    }
}