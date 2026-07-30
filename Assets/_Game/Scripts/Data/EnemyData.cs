using UnityEngine;

namespace WaveSurvival.Data
{
    /*
 * Stores enemy configuration data.
 *
 * Responsibilities:
 * - Stores enemy health.
 * - Stores movement speed.
 * - Stores attack damage.
 * - Stores enemy sprite.
 * - Stores XP reward.
 * - Allows designers to create different enemy types
 *   without changing code.
 */
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Wave Survival/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;

        public float moveSpeed = 2f;

        public float maxHealth = 10f;

        public int damage = 5;

        public int xpReward = 5;

        public Sprite enemySprite;
    }
}