using System.Threading;
using Unity.Cinemachine;
using UnityEngine;

namespace Project.Core.Scripts.Mvc.WorldCamera {
    public class WorldCameraView : MonoBehaviour {
        [Header("Virtual Camera Components")]        
        [SerializeField] private CinemachineCamera virtualCamera;
        [SerializeField] private CinemachineFollow follow;
        [SerializeField] private CinemachineRotationComposer rotationComposer;

        [Header("Camera Settings")] 
        [SerializeField] private Vector3 followOffset;
        [SerializeField] private Vector3 rotationTargetOffset;
        [SerializeField] private Vector2 rotationTargetDamping;
        
        public void SetPositionRelativeToTarget(Transform target) {
            virtualCamera.Follow = target;
            follow.FollowOffset = followOffset;
            rotationComposer.TargetOffset = rotationTargetOffset;
            rotationComposer.Damping = rotationTargetDamping;
        }

        public void LookAtTarget(Transform target) {
            virtualCamera.LookAt = target;
        }

    }
}