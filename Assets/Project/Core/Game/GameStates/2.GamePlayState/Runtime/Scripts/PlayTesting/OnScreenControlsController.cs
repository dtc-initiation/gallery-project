using Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera;

namespace Project.Core.Game.GameStates._2.GamePlayState.Runtime.Scripts.PlayTesting {
    public class OnScreenControlsController : IOnScreenControlsController {
        private OnScreenControlsView _onScreenControlsView;
        private IUICameraController _uiCameraController;

        public OnScreenControlsController(OnScreenControlsView onScreenControlsView,  IUICameraController uiCameraController) {
            _onScreenControlsView = onScreenControlsView;
            _uiCameraController = uiCameraController;
        }
        
        public void InitializeEntry() {
            _onScreenControlsView.InitializeEntryPoint(_uiCameraController.UICamera);
        }

        public void InitializeExit() {
            _onScreenControlsView.InitializeExitPoint();
        }
    }
}