using UnityEngine;
using WaveSurvival.Enemies;
using WaveSurvival.Data;

namespace WaveSurvival.Managers
{
/*
 * Controls enemy wave progression.
 *
 * Responsibilities:
 * - Starts new waves.
 * - Spawns enemies.
 * - Tracks alive enemies.
 * - Ends completed waves.
 * - Increases game difficulty.
 */
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private EnemyFactory enemyFactory;

        [SerializeField] private WaveData[] waves;

        [SerializeField] private float spawnRadius = 8f;

        private int currentWave;

        private float spawnTimer;

        private float waveTimer;

        private WaveData CurrentWave => waves[currentWave];

        private void Start()
        {
            waveTimer = CurrentWave.waveDuration;
        }

        private void Update()
        {
            waveTimer -= Time.deltaTime;
            EventManager.OnWaveTimerChanged?.Invoke(waveTimer);

            spawnTimer += Time.deltaTime;

            if (spawnTimer >= CurrentWave.spawnInterval)
            {
                SpawnEnemy();

                spawnTimer = 0;
            }

            if (waveTimer <= 0)
            {
                NextWave();
            }
        }

        private void SpawnEnemy()
        {
            int index = Random.Range(0, CurrentWave.enemies.Length);

            EnemyData enemy = CurrentWave.enemies[index];

            Vector2 spawnPosition =
                (Vector2)GameManager.Instance.PlayerTransform.position +
                Random.insideUnitCircle.normalized * spawnRadius;

            enemyFactory.SpawnEnemy(enemy, spawnPosition);
        }

        private void NextWave()
        {
            if (currentWave >= waves.Length - 1)
                return;

            currentWave++;

            waveTimer = CurrentWave.waveDuration;
        }
    }
}