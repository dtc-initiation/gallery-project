using System.Threading;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Initiator {
    public class GamePlayInitiator : IGamePlayInitiator {
        private ISceneInitiatorService _sceneInitiatorService;
        private ICommandFactory _commandFactory;
        
        public string SceneName => "GamePlayScene";
        

        [Inject]
        public GamePlayInitiator(ICommandFactory commandFactory, ISceneInitiatorService sceneInitiatorService) {
            _commandFactory = commandFactory;
            _sceneInitiatorService = sceneInitiatorService;
            _sceneInitiatorService.RegisterInitator(this);
        }
        
        public async Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            await _commandFactory.CreateAsyncVoidCommand<EnterGamePlayStateCommand>().Execute(cancellationTokenSource);
        }

        public async Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            await _commandFactory.CreateAsyncVoidCommand<StartGamePlayStateCommand>().Execute(cancellationTokenSource);
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            _sceneInitiatorService.UnregisterInitator(this);
            _commandFactory.CreateVoidCommand<ExitGamePlayStateCommand>().Execute();
            return AwaitableUtils.CompletedTask;
        }
    }
}