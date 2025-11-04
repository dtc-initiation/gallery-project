using System;
using Project.Core.Scripts.Helpers.StateMachine.Base;

namespace Project.Core.Scripts.Helpers.StateMachine.Components {
    public class FuncPredicate : IPredicate {
        private readonly Func<bool> _condition;

        public FuncPredicate(Func<bool> condition) {
            this._condition = condition;
        }

        public bool Evaluate() =>_condition.Invoke();
    }
}