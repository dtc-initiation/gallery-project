namespace Project.Core.Scripts.Services.UpdateSubscriptionManager.Base {
    public readonly struct UpdatableEntry : IComparibleEntry {
        public IUpdatable Observer { get; }
        public int Priority { get; }

        public UpdatableEntry(IUpdatable observer, int priority) {
            Observer = observer;
            Priority = priority;
        }

    }

    public class LateUpdatableEntry : IComparibleEntry {
        public ILateUpdatable Observer { get; }
        public int Priority { get; }

        public LateUpdatableEntry(ILateUpdatable observer, int priority) {
            Observer = observer;
            Priority = priority;
        }
    }

    public class FixedUpdatableEntry : IComparibleEntry {
        public IFixedUpdatable Observer { get; }
        public int Priority { get; }

        public FixedUpdatableEntry(IFixedUpdatable observer, int priority) {
            Observer = observer;
            Priority = priority;
        }
    }
}