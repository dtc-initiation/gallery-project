using System;
using System.Collections.Generic;
using System.Reflection;
using Project.Core.Scripts.Services.EventBusService.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Utils.AssemblyUtils;
using UnityEditor;

namespace Project.Core.Scripts.Services.EventBusService {
    public class EventBusService : IEventBusService {
        private List<Type> EventTypes { get; set; }
        private List<Type> EventBusTypes { get; set; }

        public EventBusService() {
            EventTypes = AssemblyUtil.ScanTypes(typeof(IEvent));
            EventBusTypes = InitializeTypeBusses();
#if UNITYEDITOR
            InitializeEditor();
#endif
        }
        
        
#if UNITY_EDITOR
        public static PlayModeStateChange PlayModeState { get; set; }
        private void InitializeEditor() {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }
        private void OnPlayModeStateChanged(PlayModeStateChange state) {
            PlayModeState = state;
            if (state == PlayModeStateChange.ExitingPlayMode) {
                ClearAllBusses();
            }
        }
#endif
        
        private List<Type> InitializeTypeBusses() {
            List<Type> eventBusTypes = new List<Type>();
            var typedef = typeof(EventBus<>);
            foreach (var eventType in EventTypes) {
                var busType = typedef.MakeGenericType(eventType);
                eventBusTypes.Add(busType);
                LogService.LogTopic($"Initialized EventBus<{eventType.Name}>");
            }

            return eventBusTypes;
        }
        
        public void ClearAllBusses() {
            LogService.LogTopic("Clearing all busses");
            foreach (var busType in EventBusTypes) {
                var clearMethod = busType.GetMethod("Clear", BindingFlags.Public);
                if (clearMethod != null) clearMethod.Invoke(null, null);
            }
        }
    }
}