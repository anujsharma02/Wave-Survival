using UnityEngine;

namespace WaveSurvival.XP
{
    public class XPOrb : MonoBehaviour
    {
        [SerializeField] private float xpAmount = 5;

        private void OnTriggerEnter2D(Collider2D other)
        {
            LevelSystem level = other.GetComponent<LevelSystem>();

            if (level == null)
                return;

            level.AddXP(xpAmount);

            gameObject.SetActive(false);
        }
    }
}