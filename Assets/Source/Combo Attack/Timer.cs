using System;

[Serializable]
public class Timer
{
    public float period;
    public float ElapsedTime;
    private Action action;

    public Timer(float period, Action action)
    {
        this.period = period;
        this.action = action;
    }

    public void Countdown(float deltaTime)
    {
        if (ElapsedTime <= period)
        {
            ElapsedTime += deltaTime;
        }
        else
        {
            action?.Invoke();
            Reset();
        }
    }

    public void Reset()
    {
        ElapsedTime = 0;
    }
}
