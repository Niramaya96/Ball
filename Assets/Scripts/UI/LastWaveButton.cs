using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _lastWaveButton;

    private void OnEnable()
    {
        _spawner.LastWave += OnLastWave;
        _lastWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }
    private void OnDisable()
    {
        _spawner.LastWave -= OnLastWave;
        _lastWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }
    public void OnLastWave()
    {
        _lastWaveButton.gameObject.SetActive(true);
    }
    public void OnNextWaveButtonClick()
    {
        
        _lastWaveButton.gameObject.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
}
