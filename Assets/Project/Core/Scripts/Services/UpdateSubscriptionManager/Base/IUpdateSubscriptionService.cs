namespace Project.Core.Scripts.Services.UpdateSubscriptionManager.Base {
    public interface IUpdateSubscriptionService {
        void RegisterUpdatable(IUpdatable updatable, int priority);
        void UnregisterUpdatable(IUpdatable updatable);
        void RegisterLateUpdatable(ILateUpdatable updatable, int priority);
        void UnregisterLateUpdatable(ILateUpdatable updatable);
        void RegisterFixedUpdatable(IFixedUpdatable updatable, int priority);
        void UnregisterFixedUpdatable(IFixedUpdatable updatable);
    }
    }