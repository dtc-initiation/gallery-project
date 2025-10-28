using System.Threading;
using Project.Core.Game.GameStates._1.LobbyState.Scripts.Mvc;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Commands {
    public class EnterLobbyStateCommand : BaseCommand, ICommandAsyncVoid {
        private ILobbyCanvasController _canvasController;
        private ILobbyButtonController _buttonController;

        public override void ResolveDependencies() {
            _canvasController = _diContainer.Resolve<ILobbyCanvasController>();
            _buttonController = _diContainer.Resolve<ILobbyButtonController>();
        }

        public Awaitable Execute(CancellationTokenSource cancellationTokenSource) {
            LogService.LogTopic("EnterLobbyStateCommand.Exceute", LogTopic.UI);
            _canvasController.InitializeEntry();
            _buttonController.InitializeEntry();
            return AwaitableUtils.CompletedTask;
        }

    }
}