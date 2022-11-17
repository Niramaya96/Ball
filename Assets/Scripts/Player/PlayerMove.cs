using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _torqueValue;

    private Rigidbody _rigitbody;
    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody>();
        _rigitbody.maxAngularVelocity = 10f;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Move()
    {
        _rigitbody.AddTorque(_camera.right * Input.GetAxis("Vertical") * _torqueValue);
        _rigitbody.AddTorque(-_camera.forward * Input.GetAxis("Horizontal") * _torqueValue);
    }
    private void Jump()
    {
        _rigitbody.AddForce(Vector3.up * 3f,ForceMode.VelocityChange);
    }
}
