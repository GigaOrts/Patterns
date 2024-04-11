using UnityEngine;

namespace Observer
{
    public class CameraController : Observer
    {
        private bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.1f;
        private PlayerController _playerController;

        private void OnEnable()
        {
            _initialPosition = transform.localPosition;
        }

        private void Update()
        {
            if (_isTurboOn)
            {
                transform.localPosition = _initialPosition +
                    (Random.insideUnitSphere * _shakeMagnitude);
            }
            else
            {
                transform.localPosition = _initialPosition;
            }
        }

        public override void Notify(Subject subject)
        {
            if (_playerController == null)
                _playerController = subject.GetComponent<PlayerController>();

            _isTurboOn = _playerController.IsTurboOn;
        }
    }
}

