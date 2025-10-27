using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Mvc.WorldCamera {
    public interface IWorldCameraController {
        void StopFollowTarget();
        void StartFollowTarget(Transform targetTransform);
    }
}