using System.Threading;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._2.GamePlayState.Scripts.Initiator {
    public class GamePlayInitiator : IGamePlayInitiator {
        private ISceneInitiatorService _sceneInitiatorService;

        [Inject]
        public GamePlayInitiator(ISceneInitiatorService sceneInitiatorService) {
            _sceneInitiatorService = sceneInitiatorService;
            _sceneInitiatorService.RegisterInitator(this);
        }
        
        public string SceneName => "GamePlayScene";
        public Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }

        public Awaitable UnloadExitPoint(CancellationTokenSource cancellationTokenSource) {
            return AwaitableUtils.CompletedTask;
        }
    }
}