using UnityEngine;

public class GameManager : Singleton<GameManager>
{
     [Header("Scene References")]
    public Transform PlayerTransform { get; private set; }
    [SerializeField] private XPPool xpPool;
    public XPPool XPPool => xpPool;
    public PlayerStats PlayerStats { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public LevelSystem LevelSystem { get; private set; }

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

    private void CachePlayerReferences()
    {
        PlayerStats = PlayerTransform.GetComponent<PlayerStats>();
        PlayerHealth = PlayerTransform.GetComponent<PlayerHealth>();
        LevelSystem = PlayerTransform.GetComponent<LevelSystem>();
    }
}