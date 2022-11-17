using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Player _player;
    [SerializeField] private CoinPool _coinPool;

    private int _currentCount;
    private void OnEnable()
    {
        _currentCount = _coinPool.CointAmount;
        _score.text = $"Осталось собрать: {_currentCount.ToString()}";
        _player.CollectCoin += OnScoreChanged;
    }
    private void OnDisable()
    {
        _player.CollectCoin -= OnScoreChanged;
    }
    private void OnScoreChanged()
    {
        _currentCount--;
        _score.text = $"Осталось собрать: {_currentCount.ToString()}";
    }
}
