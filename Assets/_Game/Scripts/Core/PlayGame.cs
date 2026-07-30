using UnityEngine;

namespace WaveSurvival.Core
{
    /*
 * Handles the Play button functionality.
 *
 * Responsibilities:
 * - Starts the gameplay.
 * - Hides the main menu.
 * - Enables gameplay objects.
 * - Can also load the gameplay scene if required.
 */
    public class PlayGame : MonoBehaviour
    {
        [SerializeField] private GameObject hudPanel;
        [SerializeField] private GameObject gameplayPanel;
        [SerializeField] private GameObject globalScripts;

        public void OnPlayButton()
        {
            gameplayPanel.SetActive(false);
            hudPanel.SetActive(true);
            globalScripts.SetActive(true);
        }
    }
}
