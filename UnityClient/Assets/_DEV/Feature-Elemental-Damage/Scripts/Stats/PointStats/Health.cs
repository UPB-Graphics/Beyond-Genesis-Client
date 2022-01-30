using UnityEngine;
using UnityEngine.Events;

namespace ElementalDamage.StatManagement
{
    [System.Serializable]
    public class Health : PointStat
    {
        public override float Value {
            get => m_Value;
            set {
                base.Value = value;
                
                if (m_Value <= 0)
                    OnDeath.Invoke();

            }
        }

        [HideInInspector] public UnityEvent OnDeath = new UnityEvent();

        public override string GetDescription() => "HP";
        public override EStatType GetStatType() => EStatType.Health;
    }
}