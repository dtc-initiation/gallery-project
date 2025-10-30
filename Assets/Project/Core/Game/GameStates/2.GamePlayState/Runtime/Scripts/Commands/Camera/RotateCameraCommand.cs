using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera;
using Project.Core.Scripts.Services.CommandFactory.Base;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands.Camera {
    public class RotateCameraCommand : BaseCommand, ICommandVoid {
        private IWorldCameraController _worldCameraController; 
        
        public override void ResolveDependencies() {
            _worldCameraController = _diContainer.Resolve<IWorldCameraController>();
        }

        public void Execute() {
            _worldCameraController.Rotate();
        }
    }
}