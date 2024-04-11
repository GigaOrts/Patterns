using UnityEngine;

namespace Countdown
{
    public class ClientTimer : MonoBehaviour
    {
        [SerializeField] private int _bonus = 1;
        [SerializeField] private float _period = 0.5f;

        private int _score;
        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer();
        }

        private void Update()
        {
            if (_timer.IsRunning == false)
                return;
            
            _timer.Countdown(Time.deltaTime);

            if (_timer.ElapsedTime >= _period)
            {
                _score += _bonus;
                _timer.Reset();
            }
        }

        private void OnGUI()
        {
            GUILayout.Label($"Bonus: {_bonus} score in {_period:0.0} sec.");
            GUILayout.Label($"Countdown: {_timer.ElapsedTime:0.0}");
            GUILayout.Label($"Score: {_score}");

            if (GUILayout.Button("SwitchTimer"))
            {
                SwitchTimer();
            }
        }

        private void SwitchTimer()
        {
            if (_timer.IsRunning)
                _timer.Pause();
            else
                _timer.Run();
        }
    }
}
