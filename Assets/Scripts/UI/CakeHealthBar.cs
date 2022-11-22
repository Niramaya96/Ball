using TMPro;
using UnityEngine;

public class CakeHealthBar : Bar
{
    [SerializeField] private Cake _cake;

    private void OnEnable()
    {
        _cake.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }
    private void OnDisable()
    {
        _cake.HealthChanged -= OnValueChanged;
    }
}
