using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera;
using Project.Core.Scripts.Services.UpdateSubscriptionManager.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.UICamera {
    public class UICameraController : IUICameraController, ILateUpdatable {
        private readonly UICameraView _uiCameraView;
        private readonly WorldCameraView _worldCameraView;
        private readonly IUpdateSubscriptionService _updateSubscriptionService;
        public Camera UICamera => _uiCameraView.Camera;

        [Inject]
        public UICameraController(UICameraView uiCameraView, WorldCameraView worldCameraView, IUpdateSubscriptionService updateSubscriptionService) {
            _uiCameraView = uiCameraView;
            _worldCameraView = worldCameraView;
            _updateSubscriptionService = updateSubscriptionService;
            _updateSubscriptionService.RegisterLateUpdatable(this, 100);
        }

        public void ManagedLateUpdate() {
            var worldCameraTransform = _worldCameraView.Camera.transform;
            UICamera.transform.localPosition =  worldCameraTransform.localPosition;
            UICamera.transform.rotation =  worldCameraTransform.rotation;
        }
    }
}