using UnityEngine;

namespace WaveSurvival.Core
{
    /*next
 * Stores gameplay area limits.
 *
 * Responsibilities:
 * - Defines playable world boundaries.
 * - Prevents objects from leaving the map.
 * - Used by enemies, projectiles, and player.
 */
    public class WorldBounds : Singleton<WorldBounds>
    {

        [Header("World Size")]
        [SerializeField] private float width = 100f;
        [SerializeField] private float height = 100f;

        public float Left => -width * 0.5f;
        public float Right => width * 0.5f;
        public float Bottom => -height * 0.5f;
        public float Top => height * 0.5f;

        protected override void Awake()
        {
            base.Awake();
        }

        public Vector3 ClampPosition(Vector3 position)
        {
            position.x = Mathf.Clamp(position.x, Left, Right);
            position.y = Mathf.Clamp(position.y, Bottom, Top);

            return position;
        }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(Vector3.zero,
            new Vector3(width, height, 0));
    }
#endif
    }
}