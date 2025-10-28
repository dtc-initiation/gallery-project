using Project.Core.Game.GameStates._1.MainMenuState.Scripts.Mvc;
using Project.Core.Scripts.Services.CommandFactory.Base;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Commands {
    public class ExitLobbyStateCommand : BaseCommand, ICommandVoid {
        private ILobbyButtonController _lobbyButtonController;
        
        public override void ResolveDependencies() {
            _lobbyButtonController = _diContainer.Resolve<ILobbyButtonController>();
        }

        public void Execute() {
            _lobbyButtonController.Dispose();
            
        }

    }
}