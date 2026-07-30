using UnityEngine;
using WaveSurvival.Data;
using WaveSurvival.Player;
using WaveSurvival.XP;
using WaveSurvival.Managers;

namespace WaveSurvival.Enemies
{
    /*
 * Represents a single enemy in the game.
 *
 * Responsibilities:
 * - Stores enemy data and statistics.
 * - Initializes enemy properties from EnemyData.
 * - Handles health, damage, and death.
 * - Drops rewards when defeated.
 * - Returns itself to the object pool if pooling is used.
 */
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public EnemyData Data { get; private set; }

        private float currentHealth;


        public void Initialize(EnemyData data)
        {
            Data = data;
            currentHealth = data.maxHealth;

            spriteRenderer.sprite = data.enemySprite;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player == null)
                return;

            player.TakeDamage(Data.damage);
        }

        private void Die()
        {
            XPOrb orb = GameManager.Instance.XPPool.GetXP();

            orb.transform.position = transform.position;

            gameObject.SetActive(false);
        }
    }
}