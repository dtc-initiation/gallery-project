using System.Threading;
using Project.Core.Game.GameStates._1.MainMenuState.Scripts.Mvc;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Commands {
    public class EnterLobbyStateCommand : BaseCommand, ICommandAsyncVoid {
        private ILobbyCanvasController _canvasController;
        private ILobbyButtonsController _buttonsController;

        public override void ResolveDependencies() {
            _canvasController = _diContainer.Resolve<ILobbyCanvasController>();
            _buttonsController = _diContainer.Resolve<ILobbyButtonsController>();            
        }

        public Awaitable Execute(CancellationTokenSource cancellationTokenSource) {
            _canvasController.InitializeEntry();
            _buttonsController.InitializeEntry();
            return AwaitableUtils.CompletedTask;
        }

    }
}