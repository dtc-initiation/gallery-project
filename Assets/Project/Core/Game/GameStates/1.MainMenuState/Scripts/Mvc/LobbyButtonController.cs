using Project.Core.Game.Scripts.States;
using Project.Core.Scripts.Services.ApplicationStateMachine.Base;
using Project.Core.Scripts.Services.Logger.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Mvc {
    public class LobbyButtonController : ILobbyButtonsController {
        private IApplicationStateService _applicationStateService;
        private readonly LobbyButtonView _lobbyButtonView;
        private readonly GamePlayState.Factory  _gamePlayStateFactory;


        [Inject]
        public LobbyButtonController(IApplicationStateService applicationStateService, LobbyButtonView lobbyButtonView, GamePlayState.Factory gamePlayStateFactory) {
            _applicationStateService = applicationStateService;
            _lobbyButtonView = lobbyButtonView;
            _gamePlayStateFactory = gamePlayStateFactory;
        }
        
        public void InitializeEntry() {
            var button = Object.Instantiate(_lobbyButtonView);
            button.Setup(OnStartButtonClicked, ApplicationStateType.GamePlay);
        }

        private void OnStartButtonClicked(ApplicationStateType toState) {
            LogService.LogTopic("Start Game Button Clicked", LogTopic.UI);
            _applicationStateService.SwitchState(_gamePlayStateFactory.Create());
        }

        public void Dispose() {
            throw new System.NotImplementedException();
        }
    }
}