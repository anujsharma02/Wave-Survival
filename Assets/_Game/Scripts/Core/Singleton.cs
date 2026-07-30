using UnityEngine;

namespace WaveSurvival.Core
{
    /*
 * Generic Singleton base class.
 *
 * Responsibilities:
 * - Ensures only one instance of a manager exists.
 * - Provides global access through Instance.
 * - Destroys duplicate objects.
 */
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }
    }
}