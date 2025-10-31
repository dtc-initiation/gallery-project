using Project.Core.Scripts.Helpers.StateMachine.Base;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera.WorldCameraState {
    public class WorldCameraStateMachine : BaseStateMachine<BaseWorldCameraState> {
        public override void Update() {
            var transition = GetTransition();
            if (transition != null) {
                ChangeState(transition.ToState);
            }
            _currentNode.State?.Update();
        }
    }
}