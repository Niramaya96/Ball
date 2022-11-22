using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _damage;
    public int Money { get; private set; }

    public void AddMoney(int money)
    {
        Money += money;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            var enemyRigidbody = enemy.GetComponent<Rigidbody>();
            enemyRigidbody.AddRelativeForce(Vector3.up * 300f);
        }
    }

}

        
    
    
