using Project.Core.Scripts.Helpers.Timers.Base;
using UnityEngine;

namespace Project.Core.Scripts.Helpers.Timers {
    public class CountDownTimer : BaseTimer {
        public CountDownTimer(float initialTime) : base(initialTime) {}
        private bool _isFinished;

        public override bool Tick(float deltaTime) {
            if (IsRunning & CurrentTime > 0) {
                CurrentTime -= deltaTime;
            }
            if (IsRunning & CurrentTime <= 0) {
                StopTimer();
                _isFinished = true;
            }
            return _isFinished;
        }

        public void ResetTimer() {
            _isFinished = false;
            CurrentTime = InitialTime;
        }
    }
}