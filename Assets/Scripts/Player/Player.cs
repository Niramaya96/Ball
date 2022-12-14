using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score;

    public UnityAction<int> ScoreChanged;

    public int Score => _score;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.DestroyEnemy();
            IncreaseScore();
        }
    }
    private void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
        
}

        
    
    
