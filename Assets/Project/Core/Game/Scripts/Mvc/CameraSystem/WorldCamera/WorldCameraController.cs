using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.UpdateSubscriptionManager.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public class WorldCameraController : IWorldCameraController, ILateUpdatable {
        private readonly WorldCameraView _worldCameraView;
        private readonly IUpdateSubscriptionService  _updateSubscriptionService;

        [Inject]
        public WorldCameraController(WorldCameraView worldCameraView, IUpdateSubscriptionService updateSubscriptionService) {
            _worldCameraView = worldCameraView;
            _updateSubscriptionService = updateSubscriptionService;
        }

        public void ManagedLateUpdate() {
            throw new System.NotImplementedException();
        }

        public void Rotate(bool isLeft) {
            // Get Current x & z is always 0
            // Rotation is across the y-axis
            // Snappable Vector
            var cameraTransform = _worldCameraView.transform.parent.transform;
            cameraTransform.Rotate(new Vector3(cameraTransform.rotation.x, cameraTransform.rotation.y - 45, 0));
            // cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.x, cameraTransform.eulerAngles.y, 0);
            
        }
    }
}