using Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting;
using Project.Core.Scripts.Services.CommandFactory.Base;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands {
    public class ExitGamePlayStateCommand : BaseCommand, ICommandVoid {
        private IOnScreenControlsController _onScreenControlsController;
        public override void ResolveDependencies() {
            _onScreenControlsController = _diContainer.Resolve<IOnScreenControlsController>();
        }

        public void Execute() {
            _onScreenControlsController.InitializeExit();
        }
    }
}