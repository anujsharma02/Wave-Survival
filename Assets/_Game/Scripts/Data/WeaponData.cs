using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Wave Survival/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;

    public float damage = 5;

    public float attackRate = 1;

    public float projectileSpeed = 7;

    public float range = 8;

    public Color projectileColor = Color.yellow;
}