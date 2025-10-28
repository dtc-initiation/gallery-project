using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.WorldCamera {
    public interface IWorldCameraController {
        void StopFollowTarget();
        void StartFollowTarget(Transform targetTransform);
    }
}