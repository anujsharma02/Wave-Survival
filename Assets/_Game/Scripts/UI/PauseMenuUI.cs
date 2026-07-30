using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using WaveSurvival.Core;
using WaveSurvival.Managers;

namespace WaveSurvival.UI
{
    /*
 * Controls the game's pause system.
 *
 * Responsibilities:
 * - Pauses and resumes gameplay.
 * - Shows pause menu.
 * - Returns to the main menu.
 */
    public class PauseMenuUI : Singleton<PauseMenuUI>
    {
        [SerializeField]
        private GameObject pausePanel;

        [Header("Texts")]
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private TMP_Text BestRecord;

        [Header("Buttons")]
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartButton;

        [SerializeField] private Button quitButton;

        [SerializeField] private Button pauseButton;

        protected override void Awake()
        {
            base.Awake();

            InitializeEvent();
            pausePanel.SetActive(false);
            titleText.text = "PAUSED";
            messageText.text = "";
        }
	private void Start(){
 BestRecord.text =
    $"Best Level : {SaveManager.GetBestLevel()}\n" +
    $"Best Time : {FormatTime(SaveManager.GetBestTime())}";

	}
        private void InitializeEvent()
        {
            resumeButton.onClick.AddListener(Resume);
            restartButton.onClick.AddListener(Restart);
            quitButton.onClick.AddListener(QuitGame);
            pauseButton.onClick.AddListener(TogglePause);
        }

        public void TogglePause()
        {
            AudioManager.Instance.PlayButton();
            bool isPaused = !pausePanel.activeSelf;

            pausePanel.SetActive(isPaused);

            Time.timeScale = isPaused ? 0f : 1f;
            titleText.text = "PAUSED";
            messageText.text = "";
            resumeButton.gameObject.SetActive(true);
        }

        public void Resume()
        {
            AudioManager.Instance.PlayButton();
            pausePanel.SetActive(false);

            Time.timeScale = 1;
        }

        public void Restart()
        {
            AudioManager.Instance.PlayButton();
            Time.timeScale = 1;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ShowGameOver(float survivalTime, int level)
        {
            AudioManager.Instance.PlayGameOver();

            pausePanel.SetActive(true);

            Time.timeScale = 0f;

            titleText.text = "GAME OVER";

            messageText.text =
                $"You Survived for {FormatTime(survivalTime)}\n" +
                $"Level Reached : {level}";

            resumeButton.gameObject.SetActive(false);

            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
	    BestRecord.text =
    $"Best Level : {SaveManager.GetBestLevel()}\n" +
    $"Best Time : {FormatTime(SaveManager.GetBestTime())}";
        }

        private string FormatTime(float seconds)
        {
            int min = Mathf.FloorToInt(seconds / 60);
            int sec = Mathf.FloorToInt(seconds % 60);

            return $"{min:00}:{sec:00}";
        }

        public void QuitGame()
        {
            AudioManager.Instance.PlayButton();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }
}