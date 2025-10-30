namespace Project.Core.Scripts.Helpers.Timers.Base {
    public abstract class BaseTimer : ITimer {
        protected float InitialTime;
        protected float CurrentTime { get; set; }
        public bool IsRunning { get; private set; }

        public float Progress => CurrentTime / InitialTime;
        
        protected BaseTimer(float initialTime) {
            InitialTime = initialTime;
            IsRunning = false;
        }
        
        public void StartTimer() {
            CurrentTime = InitialTime;
            if (!IsRunning) {
                IsRunning = true;
            }
        }

        public void StopTimer() {
            if (IsRunning) {
                IsRunning = false;
            }
        }

        public abstract bool Tick(float deltaTime);
    }
}