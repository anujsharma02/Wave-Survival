using UnityEngine;

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

        spriteRenderer.color = data.projectileColor;
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