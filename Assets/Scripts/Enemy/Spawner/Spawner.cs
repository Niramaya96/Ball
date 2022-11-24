using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Cake _target;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int,int> EnemyCountChanged;
    public event UnityAction LastWave;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }
    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy(); 
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_spawned >= _currentWave.Count)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }
            else
            {
                LastWave?.Invoke();
            }
            _currentWave = null;
        }   
    }
    private void InstantiateEnemy()
    {
        var randomPoint = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[randomPoint].position, _spawnPoints[randomPoint].rotation, _spawnPoints[randomPoint]).GetComponent<Enemy>();
        enemy.Init(_target);
    }
       
    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }
    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }
}
[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
