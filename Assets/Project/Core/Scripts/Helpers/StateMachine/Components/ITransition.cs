namespace Project.Core.Scripts.Helpers.StateMachine.Components {
    public interface ITransition {
        IState ToState { get; }
        IPredicate Condition { get; }
    }
}