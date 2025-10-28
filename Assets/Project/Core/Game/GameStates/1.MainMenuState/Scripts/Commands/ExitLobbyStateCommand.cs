using System.Threading;
using Project.Core.Game.GameStates._1.MainMenuState.Scripts.Mvc;
using Project.Core.Scripts.Services.CommandFactory.Base;
using Project.Core.Scripts.Utils;
using UnityEngine;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Commands {
    public class ExitLobbyStateCommand : BaseCommand, ICommandVoid {
        private ILobbyButtonsController _lobbyButtonsController;
        
        public override void ResolveDependencies() {
            _lobbyButtonsController = _diContainer.Resolve<ILobbyButtonsController>();
        }

        public void Execute() {
            _lobbyButtonsController.Dispose();
            
        }

    }
}