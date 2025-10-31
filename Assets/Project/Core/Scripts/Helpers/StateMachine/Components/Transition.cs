using Project.Core.Scripts.Helpers.StateMachine.Base;

namespace Project.Core.Scripts.Helpers.StateMachine.Components {
    public class Transition<TState> : ITransition<TState> where TState : BaseState {
        public TState ToState { get; }
        public IPredicate Condition { get; }

        public Transition(TState toState, IPredicate condition) {
            ToState = toState;
            Condition = condition;
        }
    }
}