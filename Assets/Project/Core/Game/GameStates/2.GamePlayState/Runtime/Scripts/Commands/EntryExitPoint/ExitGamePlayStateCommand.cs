using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Mvc.InputController;
using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting;
using Project.Core.Scripts.Services.CommandFactory.Base;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands {
    public class ExitGamePlayStateCommand : BaseCommand, ICommandVoid {
        private IOnScreenControlsController _onScreenControlsController;
        private IInputController _inputController;
        
        public override void ResolveDependencies() {
            _onScreenControlsController = _diContainer.Resolve<IOnScreenControlsController>();
            _inputController = _diContainer.Resolve<IInputController>();
        }

        public void Execute() {
            _inputController.DisableInput();
            _inputController.UnregisterInputListeners();
            _onScreenControlsController.InitializeExit();
        }
    }
}