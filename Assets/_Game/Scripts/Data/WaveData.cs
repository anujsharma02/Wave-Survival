using UnityEngine;

namespace WaveSurvival.Data
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Wave Survival/Wave Data")]
    public class WaveData : ScriptableObject
    {
        public float waveDuration = 30;

        public float spawnInterval = 1f;

        public EnemyData[] enemies;
    }
}