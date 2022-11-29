using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Cake _cake;
    [SerializeField] private GameObject _panel;
    private void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void Exit()
    {
        Application.Quit();
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
