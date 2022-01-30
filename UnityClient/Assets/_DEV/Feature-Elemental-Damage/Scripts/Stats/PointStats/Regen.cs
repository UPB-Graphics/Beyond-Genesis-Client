using UnityEngine;
using UnityEngine.Events;

namespace ElementalDamage.StatManagement
{
    public interface IRegenerable 
    {
        void Regen(float value, float deltaTime);
    }

    [System.Serializable]
    public class Regen<T> : BaseStat where T : BaseStat, IRegenerable
    {
        [HideInInspector] public T AffectedStat;
        public bool IsActive = true;

        public Regen(T affectedStat) : base()
        {
            AffectedStat = affectedStat;
        }

        public Regen(T affectedStat, float baseValue) : this(affectedStat)
        {
            Value = baseValue;
        }

        public void UpdateStat(float deltaTime)
        {
            if (IsActive)
                AffectedStat.Regen(Value, deltaTime);
        }

        public override string GetDescription() => AffectedStat.GetDescription() + " Regen";
        public override string GetValueString() => Value + "/s";
        public override EStatType GetStatType() => AffectedStat.GetStatType() switch
        {
            EStatType.Health => EStatType.HealthRegen,
            EStatType.Mana => EStatType.ManaRegen,
            _ => EStatType.None,
        };

    }
}