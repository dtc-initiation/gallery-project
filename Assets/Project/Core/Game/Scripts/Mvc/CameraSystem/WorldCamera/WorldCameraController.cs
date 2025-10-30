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

        public void Rotate() {
            
        }
        
        public void ManagedLateUpdate() {
            throw new System.NotImplementedException();
        }
    }
}