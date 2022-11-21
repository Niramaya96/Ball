using TMPro;
using UnityEngine;

public class CakeHealth : MonoBehaviour
{
    [SerializeField] private Cake _cake;
    [SerializeField] private TMP_Text _health;

    private void OnEnable()
    {
        _cake.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _cake.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(int health)
    {
        _health.text = $"У тортика осталось: {health.ToString()}";
    }
}
