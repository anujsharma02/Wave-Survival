using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int initialSize = 30;

    private readonly List<Projectile> pool = new();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, transform);
            projectile.gameObject.SetActive(false);
            pool.Add(projectile);
        }
    }

    public Projectile GetProjectile()
    {
        foreach (Projectile projectile in pool)
        {
            if (!projectile.gameObject.activeInHierarchy)
            {
                projectile.gameObject.SetActive(true);
                return projectile;
            }
        }

        Projectile newProjectile = Instantiate(projectilePrefab, transform);
        newProjectile.gameObject.SetActive(true);
        pool.Add(newProjectile);

        return newProjectile;
    }
}