using UnityEngine;

namespace WaveSurvival.Managers
{
    /*
 * Handles saving and loading player progress.
 *
 * Responsibilities:
 * - Saves game data.
 * - Loads saved progress.
 * - Stores player settings.
 * - Manages persistent game information.
 */
    public static class SaveManager
    {
        private const string BestLevelKey = "BestLevel";
        private const string BestTimeKey = "BestTime";

        public static void SaveGame(int level, float survivalTime)
        {
            if (level > GetBestLevel())
            {
                PlayerPrefs.SetInt(BestLevelKey, level);
            }

            if (survivalTime > GetBestTime())
            {
                PlayerPrefs.SetFloat(BestTimeKey, survivalTime);
            }

            PlayerPrefs.Save();
        }

        public static int GetBestLevel()
        {
            return PlayerPrefs.GetInt(BestLevelKey, 0);
        }

        public static float GetBestTime()
        {
            return PlayerPrefs.GetFloat(BestTimeKey, 0f);
        }

        public static void ClearSave()
        {
            PlayerPrefs.DeleteKey(BestLevelKey);
            PlayerPrefs.DeleteKey(BestTimeKey);
        }
    }
}