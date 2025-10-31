using Project.Core.Scripts.Helpers.StateMachine.Components;

namespace Project.Core.Scripts.Helpers.StateMachine.Base {
    public class BaseState : IState{
        public virtual void OnEnter() {}

        public virtual void Update() {}

        public virtual void FixedUpdate() {}

        public virtual void LateUpdate() {}

        public virtual void OnExit() {}
    }
}