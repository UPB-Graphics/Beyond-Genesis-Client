using UnityEngine;
using ElementalDamage.StatManagement;

namespace ElementalDamage
{
    [System.Serializable]
    public abstract class BaseResistance : BaseStat
    {
        public float DamageMultiplier {
            get => 1.0f - DamageReduction;
        }

        public float DamageReduction {
            get => 0.06f * Value / (1.0f + 0.06f * Mathf.Abs(Value));
        }


        public abstract EElementalType GetElementalType();
        public override string GetDescription() => "Res.";
        public override string GetValueString() => "(" + Value + ")" + (DamageReduction * 100).ToString("F1") + "%";

        public virtual void ApplyDamageReduction(ref BaseDamage damage)
        {
            Debug.Assert(damage.GetElementalType() == GetElementalType(), $"[WARNING] Resistance of type {GetElementalType()} reduced the value of a damage of type {damage.GetElementalType()}");

            damage.Value *= DamageMultiplier;
        }
    }

    [System.Serializable]
    public class Resistance<T> : BaseResistance where T : Element, new()
    {
        private readonly T m_Element = new T();
        public override string GetDescription() => m_Element.ToString() +  " Res.";
        public override EElementalType GetElementalType() => m_Element.GetElementalType();
        public override EStatType GetStatType() => m_Element.GetElementalType() switch
        {
            EElementalType.Physical => EStatType.PhysicalResistance,
            EElementalType.Fire => EStatType.FireResistance,
            EElementalType.Ice => EStatType.IceResistance,
            EElementalType.Earth => EStatType.EarthResistance,
            EElementalType.Lightning => EStatType.LightningResistance,
            EElementalType.Nature => EStatType.NatureResistance,
            _ => EStatType.None,
        };
    }
}