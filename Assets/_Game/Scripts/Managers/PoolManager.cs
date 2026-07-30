using UnityEngine;
using WaveSurvival.Enemies;

namespace WaveSurvival.Managers
{
    /*
 * Manages object pooling.
 *
 * Responsibilities:
 * - Creates reusable objects.
 * - Spawns pooled objects.
 * - Returns objects back to the pool.
 * - Reduces Instantiate/Destroy calls.
 */
    public class PoolManager : MonoBehaviour
    {
        [SerializeField]
        private Enemy prefab;
        [SerializeField] private int initialPoolSize = 20;

        private readonly System.Collections.Generic.List<Enemy> pool = new();

        private void Awake()
        {
            for (int i = 0; i < initialPoolSize; i++)
            {
                Enemy enemy = Instantiate(prefab, transform);
                enemy.gameObject.SetActive(false);
                pool.Add(enemy);
            }
        }

        public Enemy GetEnemy()
        {
            foreach (Enemy enemy in pool)
            {
                if (!enemy.gameObject.activeInHierarchy)
                {
                    enemy.gameObject.SetActive(true);
                    return enemy;
                }
            }

            Enemy newEnemy = Instantiate(prefab, transform);
            newEnemy.gameObject.SetActive(true);
            pool.Add(newEnemy);

            return newEnemy;
        }
    }
}