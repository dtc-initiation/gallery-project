using System.Threading;
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

        public string SceneName => "GameScene";


        [Inject]
        public GameInitiator(
            IApplicationStateService stateMachine,
            ISceneInitiatorService sceneInitiator,
            InitialStateConfig initialStateConfig,
            LobbyState.Factory lobbyStateFactory
        ) {
            _applicationStateMachine = stateMachine;
            _sceneInitiator = sceneInitiator;
            _initialStateConfig = initialStateConfig;
            _lobbyStateFactory = lobbyStateFactory;
            _sceneInitiator.RegisterInitator(this);
        }


        public async Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            IApplicationState initialState = ResolveInitialState();
            await _applicationStateMachine.EnterInitialGameState(initialState, cancellationTokenSource);
        }

        public Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            _sceneInitiator.UnregisterInitator(this);
            return AwaitableUtils.CompletedTask;
        }

        private IApplicationState ResolveInitialState() {
            return _initialStateConfig.initialStateType switch {
                ApplicationStateType.Lobby => _lobbyStateFactory.Create(),
                _ => _lobbyStateFactory.Create()
            };
        }

    }
}