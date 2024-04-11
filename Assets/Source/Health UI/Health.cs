using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float MaxValue { get; private set; }

    public event Action<float> Changed;
    
    private float _currentValue;

    private void Awake()
    {
        _currentValue = MaxValue;
    }

    public void TakeDamage(float amount)
    {
        _currentValue -= amount;

        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
        Changed?.Invoke(_currentValue);
    }
}
