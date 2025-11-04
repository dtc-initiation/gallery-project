using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera;
using Project.Core.Scripts.Services.CommandFactory.Base;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.Commands.Camera {
    public class RotateCameraCommand : BaseCommand, ICommandVoid {
        private IWorldCameraController _worldCameraController; 
        private CameraRotationEnterData _enterData;

        public RotateCameraCommand SetEnterData(CameraRotationEnterData cameraRotationEnterData) {
            _enterData = cameraRotationEnterData;
            return this;
        }
        
        public override void ResolveDependencies() {
            _worldCameraController = _diContainer.Resolve<IWorldCameraController>();
        }

        public void Execute() {
            _worldCameraController.Rotate(_enterData.IsLeft);
        }
    }
}