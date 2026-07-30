using UnityEngine;
using WaveSurvival.Data;
using WaveSurvival.Enemies;

namespace WaveSurvival.Weapon
{
    /*
 * Controls the player's weapon attack system.
 *
 * Responsibilities:
 * - Searches for the nearest enemy.
 * - Rotates towards the target.
 * - Fires projectiles.
 * - Uses weapon data for damage and cooldown.
  * - Detects enemies within attack range.
 */
    public class Projectile : MonoBehaviour
    {
        private WeaponData weaponData;
        private Vector2 direction;
        private float travelledDistance;

        [SerializeField] private SpriteRenderer spriteRenderer;

        public void Initialize(WeaponData data, Vector2 moveDirection)
        {
            weaponData = data;
            direction = moveDirection.normalized;
            travelledDistance = 0f;

            spriteRenderer.sprite = data.projectileSprite;
        }

        private void Update()
        {
            float distance = weaponData.projectileSpeed * Time.deltaTime;

            transform.Translate(direction * distance, Space.World);

            travelledDistance += distance;

            if (travelledDistance >= weaponData.range)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy == null)
                return;

            enemy.TakeDamage(weaponData.damage);

            gameObject.SetActive(false);
        }
    }
}