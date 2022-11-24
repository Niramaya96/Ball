using UnityEngine;


public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Animator _animator;

    private float _lastAttackTime;
    
    
    private void Update()
    {
        if (_lastAttackTime <= 0 && Target != null)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
    private void Attack(Cake target)
    {
        _animator.Play("Attack 02");
        target.ApplyDamage(_damage);
    }
}
