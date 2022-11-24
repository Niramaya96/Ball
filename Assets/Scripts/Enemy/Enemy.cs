using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    
    private Cake _target;
    public Cake Target => _target;

    public void Init(Cake target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        Destroy(gameObject);
    }
}
        

   
