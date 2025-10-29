using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.UpdateSubscriptionManager.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public class WorldCameraController : IWorldCameraController, ILateUpdatable {
        private readonly WorldCameraView _worldCameraView;
        private readonly IUpdateSubscriptionService  _updateSubscriptionService;
        private Transform _followTarget;

        [Inject]
        public WorldCameraController(WorldCameraView worldCameraView, IUpdateSubscriptionService updateSubscriptionService) {
            _worldCameraView = worldCameraView;
            _updateSubscriptionService = updateSubscriptionService;
        }

        public void StartFollowTarget(Transform targetTransform) {
            LogService.LogTopic($"Start follow target {targetTransform.gameObject.name}", LogTopic.Camera);
            _followTarget = targetTransform;
            SetCameraRelativeToTarget(_followTarget);
            _updateSubscriptionService.RegisterLateUpdatable(this, 100);
            
        }

        public void StopFollowTarget() {
            LogService.LogTopic($"Stop follow target", LogTopic.Camera);
            _updateSubscriptionService.UnregisterLateUpdatable(this);
            _followTarget = null;
        }

        public void ManagedLateUpdate() { }

        private void SetCameraRelativeToTarget(Transform targetTransform) {
            _worldCameraView.SetPositionRelativeToTarget(targetTransform);
            _worldCameraView.LookAtTarget(targetTransform);
        }
        
    }
}