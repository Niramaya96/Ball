using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeToReachTarget;

    private Rigidbody _rigidbody;
    private Vector3 _directionToTarget;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _directionToTarget = (Target.transform.position - transform.position).normalized;

        Move();
    }
    private void Move()
    {
        Vector3 vectorToTarget = _rigidbody.mass * (_moveSpeed * _directionToTarget - _rigidbody.velocity) / _timeToReachTarget;
        _rigidbody.MovePosition(_rigidbody.position + vectorToTarget * Time.fixedDeltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(_directionToTarget.x, 0, _directionToTarget.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.fixedDeltaTime);
    }
}
         
