using Project.Core.Scripts.Helpers.Rotation;
using Unity.Cinemachine;
using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public class WorldCameraView : MonoBehaviour, ICameraView {
        [Header("Virtual Camera Components")]
        [field: SerializeField] public Camera Camera { get; set; }

        [Header("Camera Settings")] 
        [SerializeField] private Vector3 followOffset;
        [SerializeField] private float rotationDuration;
        
        public float RotationDuration => rotationDuration;
        private Quaternion _currentRotation;
        private Quaternion _referenceRotation;

        public void Rotate(Vector3 forward) {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            _currentRotation = QuaternionUtil.SmoothDamp(transform.rotation, targetRotation, ref _referenceRotation, rotationDuration);
            transform.parent.rotation = _currentRotation;
        }
    }
}