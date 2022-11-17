using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private Vector3 _moveDirection;
    private void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && _movement._isGrounded)
            _movement.Jump();
    }


    private void FixedUpdate()
    {
        _movement.Move(_moveDirection);
    }


}
