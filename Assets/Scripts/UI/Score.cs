using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textScore;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }
    private void OnScoreChanged(int score)
    {
        _textScore.text = score.ToString();
    }
}
