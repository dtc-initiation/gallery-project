using Project.Core.Scripts.Helpers.StateMachine.Base;
using UnityEngine;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera.WorldCameraState {
    public abstract class BaseWorldCameraState : BaseState {
        public Vector3 Direction;
    }
}