using Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Mvc {
    public class LobbyCanvasController : ILobbyCanvasController{
        private LobbyCanvasView _lobbyCanvasView;
        private IUICameraController _uiCameraController;

        public LobbyCanvasController(LobbyCanvasView lobbyCanvasView, IUICameraController uiCameraController) {
            _lobbyCanvasView = lobbyCanvasView;
            _uiCameraController = uiCameraController;
        }
        
        public void InitializeEntry() {
            _lobbyCanvasView.InitializeEntryPoint(_uiCameraController.UICamera);
        }
    }
}