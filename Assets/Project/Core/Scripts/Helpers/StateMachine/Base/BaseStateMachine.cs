using System;
using System.Collections.Generic;
using Project.Core.Scripts.Helpers.StateMachine.Components;

namespace Project.Core.Scripts.Helpers.StateMachine.Base {
    public abstract class BaseStateMachine<TState> : IStateMachine where TState : BaseState {
        private StateNode _currentNode;
        private Dictionary<Type, StateNode> _stateNodes;

        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void LateUpdate();

        private ITransition GetTransition() {
            var transitions = _currentNode.Transitions;
            foreach (var transition in transitions) {
                if (transition.Condition.Evaluate()) {
                    return transition;
                };
            }
            return null;
        }

        public void SetState(TState state) {
            _currentNode = _stateNodes[state.GetType()];
            _currentNode.State.OnEnter();
        }
        
        private void ChangeState(TState state) {
            if (_currentNode.State == state) return;
            var previousState = _currentNode.State;
            var nextState = _stateNodes[state.GetType()].State;
            
            previousState.OnExit();
            nextState.OnEnter();
            _currentNode = _stateNodes[state.GetType()];
        }

        private void AddTransition(TState fromState, TState toState, IPredicate condition) {
            GetOrAddStateNode(fromState).AddTransition(GetOrAddStateNode(toState).State, condition);
        }

        private StateNode GetOrAddStateNode(TState state) {
            var node = _stateNodes.GetValueOrDefault(state.GetType());
            if (node == null) {
                node = new StateNode(state);
                _stateNodes.Add(state.GetType(), node);
            }
            return node;
        }
        
        private class StateNode {
            public TState State { get; }
            public HashSet<ITransition> Transitions { get; }

            public StateNode(TState state) {
                State = state;
                Transitions = new();
            }

            public void AddTransition(TState to, IPredicate condition) {
                Transitions.Add(new Transition(to, condition));
            }
            
        }
    }
}
