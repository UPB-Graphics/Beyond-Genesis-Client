
using System;
using System.Collections;
using System.Collections.Generic;
using ElementalDamage;
using UnityEngine;

namespace ElementalDamage.StatManagement
{
    public class Stats : ADamageable
    {
        public Health Health;
        public Mana Mana;
        public Regen<Health> HealthRegen;
        public Regen<Mana> ManaRegen;

        public Resistance<Physical> PhysicalResistance;
        public Resistance<Fire> FireResistance;
        public Resistance<Ice> IceResistance;
        public Resistance<Earth> EarthResistance;
        public Resistance<Lightning> LightningResistance;
        public Resistance<Nature> NatureResistance;

        public readonly Dictionary<EElementalType, BaseResistance> Resistances = new Dictionary<EElementalType, BaseResistance>();
        public readonly Dictionary<EStatType, BaseStat> StatDict = new Dictionary<EStatType, BaseStat>();

        private void Awake()
        {
            Resistances[EElementalType.Physical] = PhysicalResistance;
            Resistances[EElementalType.Fire] = FireResistance;
            Resistances[EElementalType.Ice] = IceResistance;
            Resistances[EElementalType.Earth] = EarthResistance;
            Resistances[EElementalType.Lightning] = LightningResistance;
            Resistances[EElementalType.Nature] = NatureResistance;

            HealthRegen.AffectedStat = Health;
            ManaRegen.AffectedStat = Mana;

            StatDict[EStatType.Health] = Health;
            StatDict[EStatType.Mana] = Mana;
            StatDict[EStatType.PhysicalResistance] = PhysicalResistance;
            StatDict[EStatType.FireResistance] = FireResistance;
            StatDict[EStatType.IceResistance] = IceResistance;
            StatDict[EStatType.EarthResistance] = EarthResistance;
            StatDict[EStatType.LightningResistance] = LightningResistance;
            StatDict[EStatType.NatureResistance] = NatureResistance;
            StatDict[EStatType.HealthRegen] = HealthRegen;
            StatDict[EStatType.ManaRegen] = ManaRegen;
        }

        private void Update()
        {
            HealthRegen.UpdateStat(Time.deltaTime);
            ManaRegen.UpdateStat(Time.deltaTime);
        }

        public bool UseMana(float value)
        {
            if (value > Mana.Value)
                return false;

            Mana.Value -= value;
            return true;
        }

        public bool ApplyEffect(EStatType statAffected, float modifier)
        {
            BaseStat stat = StatDict[statAffected];
            if (stat != null)
            {
                stat.Value += modifier;
                return true;
            }
            return false;
        }

        public bool ApplyMaxEffect(EStatType statAffected, float modifier)
        {
            BaseStat stat = StatDict[statAffected];
            if (stat != null && stat is PointStat pointStat)
            {
                pointStat.MaxValue += modifier;
                return true;
            }
            return false;
        }

        public bool ApplyTimedEffect(EStatType statAffected, float modifier, float duration)
        {
            if (ApplyEffect(statAffected, modifier))
            {
                StartCoroutine(TimedEffect(statAffected, modifier, duration));
                return true;
            }

            return false;
        }

        public bool ApplyMaxTimedEffect(EStatType statAffected, float modifier, float duration)
        {
            if (ApplyMaxEffect(statAffected, modifier))
            {
                StartCoroutine(TimedMaxEffect(statAffected, modifier, duration));
                return true;
            }
            return false;
        }

        public IEnumerator TimedEffect(EStatType statAffected, float modifier, float duration)
        {
            yield return new WaitForSeconds(duration);
            ApplyEffect(statAffected, -modifier);
        }

        public IEnumerator TimedMaxEffect(EStatType statAffected, float modifier, float duration)
        {
            
            yield return new WaitForSeconds(duration);
            ApplyMaxEffect(statAffected, -modifier);
        }

        public override void OnHit(BaseDamage damage)
        {
            base.OnHit(damage);
            Resistances[damage.GetElementalType()].ApplyDamageReduction(ref damage);
            Health.Value -= damage.Value;

            DamageNumbersManager.Instance.SpawnDamagePopup(transform.position, damage);
        }
    }
}