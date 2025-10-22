using System.Threading;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Initiator {
    public class MainMenuInitiator : ISceneInitiator, IMainMenuInitiator {
        public string SceneName => "MainMenu";

        [Inject]
        public MainMenuInitiator(IApplicationStateService applicationStateService) {}
        
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