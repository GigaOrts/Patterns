using TMPro;
using UnityEngine;

public class HealthViewText : HealthView
{
    [SerializeField] private TextMeshPro _tmpText;

    public override void UpdateHealth(float targetValue)
    {
        _tmpText.text = $"Health: {targetValue}/{MaxHealth}";
    }
}
