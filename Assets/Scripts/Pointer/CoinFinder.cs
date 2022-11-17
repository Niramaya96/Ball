using UnityEngine;

public class CoinFinder : MonoBehaviour
{
    [SerializeField] private Transform _coinPool;
    public Transform GetClosest(Vector3 pointPosition)
    {
        float minDistance = Mathf.Infinity;
        Transform closestCoin = null;
        for (int i = 0; i < _coinPool.childCount; i++)
        {
            float distance = Vector3.Distance(pointPosition, _coinPool.GetChild(i).position);
            if (distance < minDistance) 
            {
                minDistance = distance;
                closestCoin = _coinPool.GetChild(i);
            }
        }
        return closestCoin;       
    }

            
   

    
}
