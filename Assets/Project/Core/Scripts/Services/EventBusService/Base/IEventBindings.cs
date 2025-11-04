
using System;

namespace Project.Core.Scripts.Services.EventBusService.Base {
    public interface IEventBinding<TEvent> where TEvent : IEvent {
        public Action<TEvent> OnEvent { get; set; }
    }

    public class EventBinding<TEvent> : IEventBinding<TEvent> where TEvent : IEvent {
        private Action<TEvent> _onEvent = _ => { };
        Action<TEvent> IEventBinding<TEvent>.OnEvent {
            get => _onEvent;
            set => _onEvent = value;
        }

        public EventBinding(Action<TEvent> onEvent) {
            this._onEvent = onEvent;
        }

        public void Add(Action<TEvent> onEvent) => this._onEvent +=  onEvent;
        public void Remove(Action<TEvent> onEvent) => this._onEvent +=  onEvent;
    }
    
}