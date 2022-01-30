using UnityEngine;
using UnityEngine.Events;

namespace ElementalDamage.StatManagement
{
    public enum EStatType
    {
        None,
        Health,
        Mana,
        HealthRegen,
        ManaRegen,
        PhysicalResistance,
        FireResistance,
        IceResistance,
        EarthResistance,
        LightningResistance,
        NatureResistance,
    }


    [System.Serializable]
    public abstract class BaseStat
    {
        [SerializeField] protected float m_Value;
        public virtual float Value {
            get => m_Value;
            set {
                m_Value = value;
                ValueChanged.Invoke(value);
            }
        }

        [HideInInspector] public UnityEvent<float> ValueChanged;

        public BaseStat()
        {
            ValueChanged = new UnityEvent<float>();
        }


        public virtual string GetDescription() => "BaseStat";
        public virtual string GetValueString() => Value.ToString();
        public abstract EStatType GetStatType();
    }
}