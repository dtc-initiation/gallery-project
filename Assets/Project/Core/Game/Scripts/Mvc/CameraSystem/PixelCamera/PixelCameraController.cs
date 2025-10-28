using Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera;
using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.PixelCamera {
    public class PixelCameraController : IPixelCameraController{
        private readonly WorldCameraController  _worldCameraController;
        private readonly UICameraController _uiCameraController;
        
        public PixelCameraController() {}
        
        public void InitializeEntry() {
            
        }

        public void Dispose() {
            
        }
    }
}