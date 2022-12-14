using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _torqueValue;
    [SerializeField] private FloatingJoystick _joystick;

    private Rigidbody _rigitbody;
    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody>();
        _rigitbody.maxAngularVelocity = 15f;
    }
    private void FixedUpdate()
    {
        Move();
    }
  
    private void Move()
    {
        _rigitbody.AddTorque(_camera.right * _joystick.Vertical * _torqueValue);
        _rigitbody.AddTorque(-_camera.forward * _joystick.Horizontal * _torqueValue);
    }
    
}
