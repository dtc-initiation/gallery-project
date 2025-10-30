using Unity.Cinemachine;
using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public class WorldCameraView : MonoBehaviour, ICameraView {
        [Header("Virtual Camera Components")]
        [field: SerializeField] public Camera Camera { get; set; }

        [Header("Camera Settings")] 
        [SerializeField] private Vector3 followOffset;
        [SerializeField] private float rotationDuration;
        
        public void SetPositionRelativeToTarget(Transform target) {
        }

        public void LookAtTarget(Transform target) {
        }


    }
}