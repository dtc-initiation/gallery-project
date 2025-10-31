using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera.WorldCameraState {
    public class WorldCameraStateNorth : BaseWorldCameraState {
        public WorldCameraStateNorth() {
            Direction = new(2, -0.35f, 2);
        }
    }
}