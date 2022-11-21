using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction GameOver;
   public void ApplyDamage(int damage)
   {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            GameOver?.Invoke();
            Destroy(gameObject);
        }
   }
}
