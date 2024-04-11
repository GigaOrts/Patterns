using System.Collections;
using UnityEngine;

namespace EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float _duration = 3f;

        private void OnEnable()
        {
            EventBus.Subscribe(GameEventType.Countdown, StartTimer);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEventType.Countdown, StartTimer);
        }

        private void StartTimer()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            _currentTime = _duration;

            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }

            EventBus.Publish(GameEventType.Start);
        }

        private void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 100, 20), $"Countdown: {_currentTime}");
        }
    }
}

