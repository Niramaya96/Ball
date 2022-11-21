using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Cake _target;

    public Cake Target => _target;
    public int Reward => _reward;
    public event UnityAction<Enemy> Dying;

    public void Init(Cake target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

   
