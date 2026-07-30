using System;

namespace WaveSurvival.Managers
{
    /*
 * Central event system for gameplay communication.
 *
 * Responsibilities:
 * - Broadcasts game events.
 * - Reduces dependencies between scripts.
 * - Handles gameplay notifications.
 *
 * Example Events:
 * - EnemyKilled
 * - PlayerDied
 * - XPCollected
 * - WaveStarted
 * - WaveCompleted
 */
    public static class EventManager
    {
        public static Action<int> OnLevelChanged;

        public static Action<float, float> OnXPChanged;

        public static Action<float, float> OnHealthChanged;

        public static Action<float> OnWaveTimerChanged;
    }
}