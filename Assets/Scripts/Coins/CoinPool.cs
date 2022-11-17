using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private GameObject _template;
    
    private List<GameObject> _pool = new List<GameObject>();
    public int CointAmount => _amount;

    private void Start()
    {
        Initialize(_template);
    }
    private void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _amount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-11f, 11f), 0, Random.Range(-11f, 11f));
            GameObject coin = Instantiate(prefab, randomPosition, Quaternion.identity, gameObject.transform);
            _pool.Add(coin);
        }
    }
}
