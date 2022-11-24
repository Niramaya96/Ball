using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction GameOver;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void ApplyDamage(int damage)
   {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,_maxHealth);

        if (_currentHealth <= 0)
        {
            GameOver?.Invoke();
            Destroy(gameObject);
        }
   }
}
