namespace Countdown
{
    public class Timer
    {
        public bool IsRunning { get; private set; }
        public float ElapsedTime { get; private set; }

        public void Countdown(float deltaTime)
        {
            if (IsRunning == false)
                return;

            ElapsedTime += deltaTime;
        }
        
        public void Run()
        {
            IsRunning = true;
        }

        public void Pause()
        {
            IsRunning = false;
        }
        
        public void Reset()
        {
            ElapsedTime = default;
        }
    }
}
