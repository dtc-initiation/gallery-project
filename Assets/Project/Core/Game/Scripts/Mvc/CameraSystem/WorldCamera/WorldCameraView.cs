using System;
using Project.Core.Scripts.Helpers.Rotation;
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

        private Vector3 newRotation;
        private float xVel;
        private float yVel;
        private float zVel;
        
        public void Rotate(Vector3 forward) {
            Vector3 direction = forward;
            Vector3 targetRotation = Quaternion.LookRotation(direction).eulerAngles;

            newRotation = new Vector3(
                Mathf.SmoothDampAngle(newRotation.x, targetRotation.x, ref xVel, rotationDuration),
                Mathf.SmoothDampAngle(newRotation.y, targetRotation.y, ref yVel, rotationDuration),
                Mathf.SmoothDampAngle(newRotation.z, targetRotation.z, ref zVel, rotationDuration)
                );
            transform.parent.transform.eulerAngles = newRotation;

            // Quaternion targetRotation = Quaternion.LookRotation(forward);
            // _currentRotation = QuaternionUtil.SmoothDamp(transform.rotation, targetRotation, ref _referenceRotation, rotationDuration);
            // transform.parent.rotation = _currentRotation;
        }
    }
}