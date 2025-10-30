using System;
using Project.Core.Scripts.Helpers.Timers;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.UpdateSubscriptionManager.Base;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.Scripts.Mvc.CameraSystem.WorldCamera {
    public class WorldCameraController : IWorldCameraController, ILateUpdatable {
        private readonly WorldCameraView _worldCameraView;
        private readonly IUpdateSubscriptionService  _updateSubscriptionService;

        private readonly CountDownTimer _countDownTimer;
        private bool _isLeft;

        [Inject]
        public WorldCameraController(WorldCameraView worldCameraView, IUpdateSubscriptionService updateSubscriptionService) {
            _worldCameraView = worldCameraView;
            _updateSubscriptionService = updateSubscriptionService;
            _countDownTimer = new CountDownTimer(_worldCameraView.RotationDuration);
            _updateSubscriptionService.RegisterLateUpdatable(this, 0);
        }

        public void ManagedLateUpdate() {
            var isFinished = _countDownTimer.Tick(Time.deltaTime);
            if (!isFinished && _countDownTimer.IsRunning) {
                var angle = (_isLeft ? -1 : 1);
                _worldCameraView.Rotate(angle);
            }
        }

        public void Rotate(bool isLeft) {
            if (!_countDownTimer.IsRunning) {
                Debug.Log("Started Rotate Timer");
                _countDownTimer.ResetTimer();
                _countDownTimer.StartTimer();
                _isLeft = isLeft;
            }
        }
    }
}