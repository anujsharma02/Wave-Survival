using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Button pauseButton;

    private void Awake()
    {

        resumeButton.onClick.AddListener(Resume);
        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(QuitGame);
        pauseButton.onClick.AddListener(TogglePause);

        pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        bool isPaused = !pausePanel.activeSelf;

        pausePanel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}