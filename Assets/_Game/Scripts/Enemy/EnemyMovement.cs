using UnityEngine;
using WaveSurvival.Core;
using WaveSurvival.Managers;

namespace WaveSurvival.Enemies
{
    /*
 * Controls enemy movement and chasing behavior.
 *
 * Responsibilities:
 * - Finds the player's position.
 * - Moves towards the player.
 * - Updates movement every frame.
 * - Uses movement speed from EnemyData.
 */
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

            //     transform.position = Vector2.MoveTowards(
            //         transform.position,
            //         player.position,
            //         enemy.Data.moveSpeed * Time.deltaTime);

            Vector3 nextPosition = Vector2.MoveTowards(
            transform.position, player.position, enemy.Data.moveSpeed * Time.deltaTime);

            transform.position =
                WorldBounds.Instance.ClampPosition(nextPosition);
        }
    }
}