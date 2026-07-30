using UnityEngine;

namespace WaveSurvival.Data
{
    /*
 * Script: WeaponData
 * ------------------
 * ScriptableObject that stores weapon configuration.
 *
 * Responsibilities:
 * - Stores weapon damage.
 * - Stores attack speed.
 * - Stores attack range.
 *
 * Purpose:
 * - Allows creation of multiple weapon types
 *   using the same Weapon script.
 */
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Wave Survival/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;

        public float damage = 5;

        public float attackRate = 1;

        public float projectileSpeed = 7;

        public float range = 8;

        public Sprite projectileSprite;
    }
}