using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Cake _target;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delayBetweenSpawn;

    private float _timeAfterLastSpawn;

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _delayBetweenSpawn)
        {
            _timeAfterLastSpawn = 0;    
            SetEnemy();
        }
    }
    private void SetEnemy()
    {
        var randomPoint = Random.Range(0, _spawnPoints.Length);
        var enemy = Instantiate(_enemyPrefab, _spawnPoints[randomPoint].position, _spawnPoints[randomPoint].rotation).GetComponent<Enemy>();
        enemy.Init(_target);
    }
}

