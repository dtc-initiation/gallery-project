using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public interface IWorldCameraController {
        void StopFollowTarget();
        void StartFollowTarget(Transform targetTransform);
    }
}