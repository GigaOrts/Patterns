using UnityEngine;

namespace Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
                if (_playerController)
                    _playerController.TakeDamage(15f);

            if (GUILayout.Button("Toggle Turbo"))
                if (_playerController)
                    _playerController.ToggleTurbo();
        }
    }
}

