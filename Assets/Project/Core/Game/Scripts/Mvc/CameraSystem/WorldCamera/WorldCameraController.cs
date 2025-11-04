using Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera.WorldCameraState;
using Project.Core.Scripts.Helpers.StateMachine.Components;
using Project.Core.Scripts.Helpers.Timers;
using Project.Core.Scripts.Services.UpdateSubscriptionManager.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public class WorldCameraController : IWorldCameraController, ILateUpdatable {
        private readonly WorldCameraView _worldCameraView;
        private readonly WorldCameraStateMachine _worldCameraStateMachine;
        private readonly IUpdateSubscriptionService _updateSubscriptionService;

        private readonly WorldCameraStateNorth _stateNorth;
        private readonly WorldCameraStateSouth _stateSouth;
        private readonly WorldCamerStateEast _stateEast;
        private readonly WorldCameraStateWest _stateWest;

        private readonly CountDownTimer _countDownTimer;
        private bool _isLeft;

        [Inject]
        public WorldCameraController(WorldCameraView worldCameraView, IUpdateSubscriptionService updateSubscriptionService) {
            _worldCameraView = worldCameraView;
            _updateSubscriptionService = updateSubscriptionService;
            
            _countDownTimer = new CountDownTimer(_worldCameraView.RotationDuration);
            _worldCameraStateMachine = new WorldCameraStateMachine();
            _stateNorth = new WorldCameraStateNorth();
            _stateSouth = new WorldCameraStateSouth();
            _stateEast = new WorldCamerStateEast();
            _stateWest = new WorldCameraStateWest();
            SetupStateMachine();
            
            _updateSubscriptionService.RegisterLateUpdatable(this, 0);
        }

        public void SetupStateMachine() {
            _worldCameraStateMachine.AddTransition(_stateNorth, _stateEast, new FuncPredicate(() => !_isLeft));
            _worldCameraStateMachine.AddTransition(_stateNorth, _stateWest, new FuncPredicate(() => _isLeft));
            _worldCameraStateMachine.AddTransition(_stateEast, _stateNorth, new FuncPredicate(() => _isLeft));
            _worldCameraStateMachine.AddTransition(_stateEast,  _stateSouth, new FuncPredicate(() => !_isLeft));
            _worldCameraStateMachine.AddTransition(_stateSouth, _stateEast, new FuncPredicate(() => _isLeft));
            _worldCameraStateMachine.AddTransition(_stateSouth, _stateWest, new FuncPredicate(() => !_isLeft));
            _worldCameraStateMachine.AddTransition(_stateWest, _stateSouth, new FuncPredicate(() => _isLeft));
            _worldCameraStateMachine.AddTransition(_stateWest, _stateNorth, new FuncPredicate(() => !_isLeft));
            _worldCameraStateMachine.SetState(_stateNorth);
            _worldCameraStateMachine.Update();
        }
        
        
        public void ManagedLateUpdate() {
            var isFinished = _countDownTimer.Tick(Time.deltaTime);
            _worldCameraView.Rotate(_worldCameraStateMachine._currentNode.State.Direction);
        }

        public void Rotate(bool isLeft) {
            if (!_countDownTimer.IsRunning) {
                Debug.Log("Started Rotate Timer");
                _countDownTimer.ResetTimer();
                _countDownTimer.StartTimer();
                _isLeft = isLeft;
                
                Debug.Log("IsLeft: " + _isLeft);
                _worldCameraStateMachine.Update();
                Debug.Log(_worldCameraStateMachine._currentNode.State);
                Debug.Log(_worldCameraStateMachine._currentNode.State.Direction);
            }
        }
    }
}