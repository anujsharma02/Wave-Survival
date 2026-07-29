using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public EnemyData Data { get; private set; }

    private float currentHealth;

    public void Initialize(EnemyData data)
    {
        Data = data;
        currentHealth = data.maxHealth;

        spriteRenderer.color = data.enemyColor;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}