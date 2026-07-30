using System.Diagnostics;
using UnityEngine;
using WaveSurvival.Managers;

namespace WaveSurvival.XP
{
    public class LevelSystem : MonoBehaviour
    {
        public int Level { get; private set; } = 1;

        public float CurrentXP { get; private set; }

        public float XPToNextLevel { get; private set; } = 20;

        public void AddXP(float amount)
        {
            CurrentXP += amount;

            EventManager.OnXPChanged?.Invoke(CurrentXP, XPToNextLevel);

            while (CurrentXP >= XPToNextLevel)
            {
                CurrentXP -= XPToNextLevel;

                Level++;

                XPToNextLevel *= 1.4f;

                EventManager.OnLevelChanged?.Invoke(Level);

                EventManager.OnXPChanged?.Invoke(CurrentXP, XPToNextLevel);
            }
        }
    }
}