using System.Threading;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Initiator {
    public class LobbyInitiator : ISceneInitiator, ILobbyInitiator {
        private readonly ICommandFactory _commandFactory;
        private readonly ISceneInitiatorService _sceneInitiatorService;
        private readonly IApplicationStateService _applicationStateService;
        public string SceneName => "MainMenuScene";

        [Inject]
        public LobbyInitiator(
            ICommandFactory commandFactory,
            ISceneInitiatorService sceneInitiatorService,
            IApplicationStateService applicationStateService
        ) {
            _commandFactory = commandFactory;
            _sceneInitiatorService = sceneInitiatorService;
            _applicationStateService = applicationStateService;
            _sceneInitiatorService.RegisterInitator(this);
        }
        
        public Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            _sceneInitiatorService.UnregisterInitator(this);
            return AwaitableUtils.CompletedTask;
        }
    }
}