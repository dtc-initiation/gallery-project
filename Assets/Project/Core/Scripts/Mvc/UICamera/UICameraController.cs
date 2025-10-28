using UnityEngine;
using Zenject;

namespace Project.Core.Scripts.Mvc.UICamera {
    public class UICameraController : IUICameraController {
        private readonly UICameraView _uiCameraView;
        public Camera UICamera => _uiCameraView.Camera;

        [Inject]
        public UICameraController(UICameraView uiCameraView) {
            _uiCameraView = uiCameraView;
        }
    }
}