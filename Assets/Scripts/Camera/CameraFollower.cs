using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _smoothing = 15f;
    
    private Vector3 _offset = new Vector3(0,4,-3);

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, _targetObject.transform.position + _offset, _smoothing * Time.deltaTime);
        transform.position = nextPosition;
    }
}

        
        
        
    
        
        
