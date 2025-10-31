namespace Project.Core.Scripts.Helpers.StateMachine.Components {
    public interface IState {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void LateUpdate();
        void OnExit();
    }
}