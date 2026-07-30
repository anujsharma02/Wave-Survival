using UnityEngine;
using WaveSurvival.Core;
using WaveSurvival.Pool;
using WaveSurvival.Player;
using WaveSurvival.XP;

namespace WaveSurvival.Managers
{
    /*
 * Main controller for the game.
 *
 * Responsibilities:
 * - Stores global game references.
 * - Keeps track of the Player.
 * - Provides easy access through Singleton.
 * - Initializes important gameplay systems.
 */
    public class GameManager : Singleton<GameManager>
    {
        [Header("Scene References")]
        public Transform PlayerTransform { get; private set; }
        [SerializeField] private XPPool xpPool;
        public XPPool XPPool => xpPool;
        public PlayerStats PlayerStats { get; private set; }
        public PlayerHealth PlayerHealth { get; private set; }
        public LevelSystem LevelSystem { get; private set; }
        public float GameTime { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            GameObject player = GameObject.FindGameObjectWithTag
            ("Player");

            if (player != null)
            {
                PlayerTransform = player.transform;
            }
            else
            {
                Debug.LogWarning("Player with tag 'Player' not found.");
                return;
            }
            CachePlayerReferences();
        }
        private void Update()
        {
            if (Time.timeScale == 0)
                return;

            GameTime += Time.deltaTime;
        }
        private void CachePlayerReferences()
        {
            PlayerStats = PlayerTransform.GetComponent<PlayerStats>();
            PlayerHealth = PlayerTransform.GetComponent<PlayerHealth>();
            LevelSystem = PlayerTransform.GetComponent<LevelSystem>();
        }
    }
}