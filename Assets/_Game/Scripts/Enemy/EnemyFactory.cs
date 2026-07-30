using UnityEngine;

using WaveSurvival.Managers;
using WaveSurvival.Data;

namespace WaveSurvival.Enemies
{
    /*
 * Spawns enemies into the game world.
 *
 * Responsibilities:
 * - Creates enemies at spawn locations.
 * - Selects enemy types.
 * - Works with WaveManager.
 * - Uses object pooling for better performance.
 */
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private PoolManager poolManager;

        public Enemy SpawnEnemy(EnemyData data, Vector2 position)
        {
            Enemy enemy = poolManager.GetEnemy();

            enemy.transform.position = position;

            enemy.Initialize(data);

            return enemy;
        }
    }
}