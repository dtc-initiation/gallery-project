using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.Logger.Base;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Mvc {
    public class LobbyButtonController : ILobbyButtonController {
        private readonly IApplicationStateService _applicationStateService;
        private readonly LobbyButtonView _lobbyButtonView;
        private readonly GamePlayState.Factory  _gamePlayStateFactory;


        public LobbyButtonController(LobbyButtonView lobbyButtonView, IApplicationStateService applicationStateService, GamePlayState.Factory gamePlayStateFactory) {
            _lobbyButtonView = lobbyButtonView;
            _applicationStateService = applicationStateService;
            _gamePlayStateFactory = gamePlayStateFactory;
        }
        
        public void InitializeEntry() {
            _lobbyButtonView.Setup(OnStartButtonClicked, ApplicationStateType.GamePlay);
        }

        private void OnStartButtonClicked(ApplicationStateType toState) {
            _applicationStateService.SwitchState(_gamePlayStateFactory.Create());
        }

        public void Dispose() {
            _lobbyButtonView.RemoveListeners();
        }
    }
}