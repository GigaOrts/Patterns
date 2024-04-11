using UnityEngine;

namespace Observer
{
    public class HUDController : Observer
    {
        public int X = 50;
        public int Y = 50;
        public int Width = 200;
        public int Height = 100;
        private bool _isTurboOn;
        private float _currentHealth;
        private PlayerController _playerController;

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(X, Y, Width, Height));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label($"Health: {_currentHealth}");
            GUILayout.EndHorizontal();

            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }

            if (_currentHealth <= 50f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Warning: Low Health");
                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();
        }

        public override void Notify(Subject subject)
        {
            if (_playerController == null)
                _playerController = subject.GetComponent<PlayerController>();

            if (_playerController)
            {
                _isTurboOn = _playerController.IsTurboOn;
                _currentHealth = _playerController.CurrentHealth;
            }
        }
    }
}

