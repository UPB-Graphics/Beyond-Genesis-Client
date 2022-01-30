using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ElementalDamage.StatManagement
{
    public class HealthBar : Bar<Health>
    {
        [SerializeField] private Stats m_Stats;

        private void OnValidate()
        {
            if (m_Stats == null)
                m_Stats = GetComponentInParent<Stats>();
        }

        private void Awake()
        {
            Stat = m_Stats.Health;
        }
    }
}
