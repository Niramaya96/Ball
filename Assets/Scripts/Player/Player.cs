using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction CollectCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
            CollectCoin?.Invoke();
    }
}

        
    
    
