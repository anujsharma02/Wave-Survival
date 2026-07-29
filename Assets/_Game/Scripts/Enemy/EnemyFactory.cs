using UnityEngine;

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