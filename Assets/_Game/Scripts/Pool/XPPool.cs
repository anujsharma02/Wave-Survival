using System.Collections.Generic;
using UnityEngine;
using WaveSurvival.XP;

namespace WaveSurvival.Pool
{
       /*
 * Central manager for all object pools.
 *
 * Responsibilities:
 * - Registers multiple object pools.
 * - Returns pooled objects on request.
 * - Creates pools during game initialization.
 */
    public class XPPool : MonoBehaviour
    {
        [SerializeField] private XPOrb xpPrefab;
        [SerializeField] private int initialSize = 30;

        private readonly List<XPOrb> pool = new();

        private void Awake()
        {
            for (int i = 0; i < initialSize; i++)
            {
                XPOrb orb = Instantiate(xpPrefab, transform);
                orb.gameObject.SetActive(false);
                pool.Add(orb);
            }
        }

        public XPOrb GetXP()
        {
            foreach (XPOrb orb in pool)
            {
                if (!orb.gameObject.activeInHierarchy)
                {
                    orb.gameObject.SetActive(true);
                    return orb;
                }
            }

            XPOrb newOrb = Instantiate(xpPrefab, transform);
            newOrb.gameObject.SetActive(true);
            pool.Add(newOrb);

            return newOrb;
        }
    }
}