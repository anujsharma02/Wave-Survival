using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Wave Survival/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    public float moveSpeed = 2f;

    public float maxHealth = 10f;

    public int damage = 5;

    public int xpReward = 5;

    public Color enemyColor = Color.red;
}