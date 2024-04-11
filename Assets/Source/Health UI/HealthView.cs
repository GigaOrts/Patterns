using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected float MaxHealth => _health.MaxValue;

    private void Awake()
    {
        _health.Changed += UpdateHealth;
        UpdateHealth(MaxHealth);
    }

    public abstract void UpdateHealth(float targetValue);
}
