using System.Collections;
using UnityEngine;

namespace Countdown2
{
    public class TimerMonobeh : MonoBehaviour
    {
        public bool IsRunning { get; private set; }
        public float ElapsedTime { get; private set; }

        public void Run()
        {
            IsRunning = true;
            StartCoroutine(Countdown());
        }

        public void Pause()
        {
            IsRunning = false;
        }

        public void ResetElapsedTime()
        {
            ElapsedTime = default;
        }

        private IEnumerator Countdown()
        {
            while (IsRunning)
            {
                ElapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
