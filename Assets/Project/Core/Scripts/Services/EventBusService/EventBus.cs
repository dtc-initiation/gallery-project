using System.Collections.Generic;
using Project.Core.Scripts.Services.EventBusService.Base;
using Project.Core.Scripts.Services.Logger.Base;

namespace Project.Core.Scripts.Services.EventBusService {
    public class EventBus<TEvent> : IEventBus<TEvent> where TEvent : IEvent {
        
        private readonly HashSet<IEventBinding<TEvent>> bindings = new ();
        
        public void Register(EventBinding<TEvent> binding) => bindings.Add(binding);
        public void Unregister(EventBinding<TEvent> binding) => bindings.Remove(binding);

        public void Raise(TEvent @event) {
            foreach (var binding in bindings) {
                binding.OnEvent.Invoke(@event);
            }
        }

        public void Clear() {
            LogService.LogTopic($"Clearing {typeof(TEvent)} bindings");
            bindings.Clear();
        }
    }
}