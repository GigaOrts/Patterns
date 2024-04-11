using UnityEngine;
using EventBus;

namespace Observer
{
    public class PlayerController : Subject
    {
        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;

        public bool IsTurboOn { get; private set; }

        [SerializeField] private float _health = 100f;
        public float CurrentHealth => _health;

        private void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();
            _cameraController = FindObjectOfType<CameraController>();
        }

        private void Start()
        {
            StartEngine();
        }

        private void StartEngine()
        {
            _isEngineOn = true;
            NotifyObservers();
        }

        private void OnEnable()
        {
            Attach(_cameraController);
            Attach(_hudController);
        }

        private void OnDisable()
        {
            Detach(_cameraController);
            Detach(_hudController);
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn)
                IsTurboOn = !IsTurboOn;

            NotifyObservers();
        }

        public void TakeDamage(float amount)
        {
            _health -= amount;
            IsTurboOn = false;

            NotifyObservers();

            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}


