using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private string _gameSceneName;
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OpenGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OpenGame);
    }

    public void OpenGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}
