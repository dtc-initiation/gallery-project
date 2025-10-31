using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera.WorldCameraState {
    public class WorldCamerStateEast : BaseWorldCameraState {
        public WorldCamerStateEast() {
            Direction = new(2, -0.35f, -2);
        }
    }
    
}