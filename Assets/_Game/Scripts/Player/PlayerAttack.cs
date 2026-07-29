using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponData[] ownedWeapons;
    private int currentWeapon;
    [SerializeField] private ProjectilePool projectilePool;
    [SerializeField] private float attackRadius = 6f;
    private PlayerStats playerStats;

    private float timer;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        float attackRate = ownedWeapons[currentWeapon].attackRate * playerStats.AttackSpeedMultiplier;

        if (timer < 1f / attackRate)
            return;

        Enemy target = FindClosestEnemy();

        if (target == null)
            return;

        Shoot(target);

        timer = 0f;
    }

    private Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        Enemy closest = null;
        float closestDistance = attackRadius;

        foreach (Enemy enemy in enemies)
        {
            if (!enemy.gameObject.activeInHierarchy)
                continue;

            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }

    private void Shoot(Enemy target)
    {
        Projectile projectile = projectilePool.GetProjectile();

        projectile.transform.position = transform.position;

        Vector2 direction =
            target.transform.position - transform.position;

        float damage = ownedWeapons[currentWeapon].damage * playerStats.DamageMultiplier;

        projectile.Initialize(ownedWeapons[currentWeapon], direction);
    }
}