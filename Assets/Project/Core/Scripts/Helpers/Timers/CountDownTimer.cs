using Project.Core.Scripts.Helpers.Timers.Base;

namespace Project.Core.Scripts.Helpers.Timers {
    public class CountDownTimer : BaseTimer{
        public CountDownTimer(float initialTime) : base(initialTime) {}

        public override bool Tick(float deltaTime) {
            if (IsRunning & CurrentTime > 0) {
                CurrentTime -= deltaTime;
            }
            if (IsRunning & CurrentTime <= 0) {
                StopTimer();
                return true;
            }
            return false;
        }

        public void ResetTimer() {
            CurrentTime = InitialTime;
        }
    }
}