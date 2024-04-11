using Observer;
using UnityEngine;

namespace EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private bool _isButtonEnabled;

        private void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<PlayerController>();

            _isButtonEnabled = true;
        }

        private void OnEnable()
        {
            EventBus.Subscribe(GameEventType.Stop, Restart);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEventType.Stop, Restart);
        }

        private void Restart()
        {
            _isButtonEnabled = true;
        }

        private void OnGUI()
        {
            if (_isButtonEnabled)
            {
                if (GUILayout.Button("Start Countdown"))
                {
                    _isButtonEnabled = false;
                    EventBus.Publish(GameEventType.Countdown);
                }
            }
        }
    }
}

