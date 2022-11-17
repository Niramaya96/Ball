using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigitbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    public bool _isGrounded {get; private set;}
    
    private Vector3 _surfaceNormal;
   public void Move(Vector3 direction)
   {
        Vector3 directionAlongSurface = Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_moveSpeed * Time.deltaTime);

        _rigitbody.MovePosition(_rigitbody.position + offset);
   }

    private Vector3 Project(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _surfaceNormal) * _surfaceNormal;
    }
    private void OnCollisionStay(Collision collision)
    {
        _surfaceNormal = collision.contacts[0].normal;

        float dot = Vector3.Dot(_surfaceNormal, Vector3.up);

        if (dot > 0.5f)
            _isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
    public void Jump()
    {
        _rigitbody.AddForce(Vector3.up * _jumpForce,ForceMode.Impulse);
    }
}
