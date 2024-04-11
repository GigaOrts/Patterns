using UnityEngine;

namespace EventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool _isDisplayOn;

        private void OnEnable()
        {
            EventBus.Subscribe(GameEventType.Start, DisplayHUD);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEventType.Start, DisplayHUD);
        }

        private void DisplayHUD()
        {
            _isDisplayOn = true;
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 200, 100));
            if (_isDisplayOn)
            {
                if (GUILayout.Button("Stop game"))
                {
                    _isDisplayOn = false;
                    EventBus.Publish(GameEventType.Stop);
                }
            }
        }
    }
}

