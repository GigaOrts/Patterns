using UnityEngine;

namespace EventBus
{
    public class PlayerController : MonoBehaviour
    {
        private string _status;

        private void OnEnable()
        {
            EventBus.Subscribe(GameEventType.Start, StartPlayer);
            EventBus.Subscribe(GameEventType.Stop, StopPlayer);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEventType.Start, StartPlayer);
            EventBus.Unsubscribe(GameEventType.Stop, StopPlayer);
        }

        private void StartPlayer()
        {
            _status = "Started";
        }

        private void StopPlayer()
        {
            _status = "Stopped";
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10, 20, 200, 20), $"PLAYER STATUS: {_status}");
        }
    }
}


