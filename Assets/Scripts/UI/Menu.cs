using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Cake _cake;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textScore;
    private void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
        _textScore.text = $"Your score: {_player.Score}";
    }
    public void RestartGame()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    private void OnEnable()
    {
        _cake.GameOver += OpenPanel;
    }
    private void OnDisable()
    {
        _cake.GameOver += OpenPanel;
    }
}
