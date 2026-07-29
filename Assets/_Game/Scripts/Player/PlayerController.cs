using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private InputReader inputReader;
    private PlayerStats playerStats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputReader = GetComponent<InputReader>();

        playerStats = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = inputReader.MoveInput * moveSpeed * playerStats.MoveSpeedMultiplier;
    }
}