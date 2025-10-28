using System.Threading;
using Project.Core.Game.GameStates._1.LobbyState.Scripts.Commands;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Initiator {
    public class LobbyInitiator : ISceneInitiator, ILobbyInitiator {
        private readonly ICommandFactory _commandFactory;
        private readonly ISceneInitiatorService _sceneInitiatorService;
        public string SceneName => "LobbyScene";

        [Inject]
        public LobbyInitiator(ICommandFactory commandFactory, ISceneInitiatorService sceneInitiatorService) {
            _commandFactory = commandFactory;
            _sceneInitiatorService = sceneInitiatorService;
            _sceneInitiatorService.RegisterInitator(this);
        }
        
        public async Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            await _commandFactory.CreateAsyncVoidCommand<EnterLobbyStateCommand>().Execute(cancellationTokenSource);
        }

        public Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            _sceneInitiatorService.UnregisterInitator(this);
            _commandFactory.CreateVoidCommand<ExitLobbyStateCommand>().Execute();
            return AwaitableUtils.CompletedTask;
        }
    }
}