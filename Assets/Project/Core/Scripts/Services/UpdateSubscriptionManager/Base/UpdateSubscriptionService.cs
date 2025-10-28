using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.Scripts.Services.UpdateSubscriptionManager.Base {
    public class UpdateSubscriptionService : MonoBehaviour, IUpdateSubscriptionService {
        private readonly List<UpdatableEntry> _updateObservers = new ();
        private readonly List<UpdatableEntry> _addPendingUpdateObservers = new();
        private readonly List<IUpdatable> _removePendingUpdateObservers = new ();

        private readonly List<LateUpdatableEntry> _lateUpdateObservers = new ();
        private readonly List<LateUpdatableEntry> _addPendingLateUpdateObservers = new ();
        private readonly List<ILateUpdatable> _removePendingLateUpdateObservers = new ();

        private readonly List<FixedUpdatableEntry> _fixedUpdateObservers = new ();
        private readonly List<FixedUpdatableEntry> _addPendingFixedUpdateObservers = new ();
        private readonly List<IFixedUpdatable> _removePendingFixedUpdateObservers = new ();

        private readonly UpdatePriorityComparer<UpdatableEntry> _updatePriorityComparer = new();
        private readonly UpdatePriorityComparer<LateUpdatableEntry> _lateUpdatePriorityComparer = new();
        private readonly UpdatePriorityComparer<FixedUpdatableEntry> _fixedUpdatePriorityComparer = new();

        private void Update() {
            ProcessPendingUpdates();
            for (int i = 0; i < _updateObservers.Count; ++i) {
                _updateObservers[i].Observer.ManagedUpdate();
            }
            
        }

        private void LateUpdate() {
            ProcessPendingLateUpdates();
            for (int i = 0; i < _lateUpdateObservers.Count; ++i) {
                _lateUpdateObservers[i].Observer.ManagedLateUpdate();
            }
        }

        private void FixedUpdate() {
            ProcessPendingFixedUpdates();
            for (int i = 0; i < _fixedUpdateObservers.Count; ++i) {
                _fixedUpdateObservers[i].Observer.ManagedFixedUpdate();
            }
        }

        private void ProcessPendingUpdates() {
            if (_removePendingUpdateObservers.Count > 0) {
                _updateObservers.RemoveAll(entry => _removePendingUpdateObservers.Contains(entry.Observer));
                _removePendingUpdateObservers.Clear();
            }

            if (_addPendingUpdateObservers.Count > 0) {
                _updateObservers.AddRange(_addPendingUpdateObservers);
                _addPendingUpdateObservers.Clear();
                _updateObservers.Sort(_updatePriorityComparer);
            }
        }

        private void ProcessPendingLateUpdates() {
            if (_removePendingLateUpdateObservers.Count > 0) {
                _lateUpdateObservers.RemoveAll(entry => _removePendingLateUpdateObservers.Contains(entry.Observer));
                _removePendingLateUpdateObservers.Clear();
            }

            if (_addPendingLateUpdateObservers.Count > 0) {
                _lateUpdateObservers.AddRange(_addPendingLateUpdateObservers);
                _addPendingLateUpdateObservers.Clear();
                _lateUpdateObservers.Sort(_lateUpdatePriorityComparer);
            }
        }

        private void ProcessPendingFixedUpdates() {
            if (_removePendingFixedUpdateObservers.Count > 0) {
                _fixedUpdateObservers.RemoveAll(entry => _removePendingFixedUpdateObservers.Contains(entry.Observer));
                _removePendingFixedUpdateObservers.Clear();
            }

            if (_addPendingFixedUpdateObservers.Count > 0) {
                _fixedUpdateObservers.AddRange(_addPendingFixedUpdateObservers);
                _addPendingFixedUpdateObservers.Clear();
                _fixedUpdateObservers.Sort(_fixedUpdatePriorityComparer);
            }
        }
        
        
        public void RegisterUpdatable(IUpdatable updatable, int priority) {
            _addPendingUpdateObservers.Add(new UpdatableEntry (updatable, priority));
        }

        public void UnregisterUpdatable(IUpdatable updatable) {
            _removePendingUpdateObservers.Add(updatable);
        }

        public void RegisterLateUpdatable(ILateUpdatable updatable, int priority) {
            _addPendingLateUpdateObservers.Add(new LateUpdatableEntry(updatable, priority));
        }

        public void UnregisterLateUpdatable(ILateUpdatable updatable) {
            _removePendingLateUpdateObservers.Add(updatable);
        }

        public void RegisterFixedUpdatable(IFixedUpdatable updatable, int priority) {
            _addPendingFixedUpdateObservers.Add(new FixedUpdatableEntry(updatable, priority));
        }

        public void UnregisterFixedUpdatable(IFixedUpdatable updatable) {
            _removePendingFixedUpdateObservers.Add(updatable);
        }
    }
}