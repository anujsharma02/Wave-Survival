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