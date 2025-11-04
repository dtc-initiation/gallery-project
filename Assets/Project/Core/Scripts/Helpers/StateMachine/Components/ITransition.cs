using Project.Core.Scripts.Helpers.StateMachine.Base;

namespace Project.Core.Scripts.Helpers.StateMachine.Components {
    public interface ITransition<out TState> where TState : BaseState {
        TState ToState { get; }
        IPredicate Condition { get; }
    }
}