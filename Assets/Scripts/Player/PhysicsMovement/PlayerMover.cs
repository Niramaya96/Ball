using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private float _rotationSensitivity;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    
    private float _xRotation;
    private Rigidbody _rigitbody;
    private bool _isGrounded = false;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigitbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(1))
            Rotate();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
        
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.z = Input.GetAxis("Vertical");
        
        Vector3 localMoveDirection = transform.TransformVector(_moveDirection);

        _rigitbody.MovePosition(_rigitbody.position + localMoveDirection * _moveSpeed * Time.fixedDeltaTime);
        
    }
    private void Rotate()
    {
           var rotateVectorY = Input.GetAxis("Mouse X");
            transform.Rotate(0, rotateVectorY * _rotationSensitivity, 0);
    } 
        
    private void Jump()
    {
            _rigitbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
        
    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(normal, Vector3.up);

        if (dot > 0.5f)
        _isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }




}
