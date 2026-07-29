using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (GameManager.Instance == null)
            return;

        Transform player = GameManager.Instance.PlayerTransform;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            enemy.Data.moveSpeed * Time.deltaTime);
    }
}