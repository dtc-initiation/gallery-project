namespace Project.Core.Scripts.Services.EventBusService.Base {
    public interface IEventBus<TEvent> where TEvent : IEvent {
        void Register(EventBinding<TEvent> binding);
        void Unregister(EventBinding<TEvent> binding);
    }
}