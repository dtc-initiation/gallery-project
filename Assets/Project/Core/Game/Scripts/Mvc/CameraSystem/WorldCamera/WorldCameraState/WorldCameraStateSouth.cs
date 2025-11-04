using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera.WorldCameraState {
    public class WorldCameraStateSouth : BaseWorldCameraState {
        public WorldCameraStateSouth() {
            Direction = new(-2, -0.35f, -2);
        }
    }
}