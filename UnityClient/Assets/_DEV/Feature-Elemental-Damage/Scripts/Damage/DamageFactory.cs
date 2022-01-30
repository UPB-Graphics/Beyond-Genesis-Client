using UnityEngine;

namespace ElementalDamage
{
    [System.Serializable]
    public class DamageBlueprint
    {
        public EElementalType type;
        public float value;

        public BaseDamage CreateDamage()
        {
            return DamageFactory.CreateDamage(this);
        }
    }

    public static class DamageFactory
    {
        public static BaseDamage CreateDamage(EElementalType type, float value) => type switch
        {
            EElementalType.Physical => new Damage<Physical>(value),
            EElementalType.Fire => new Damage<Fire>(value),
            EElementalType.Ice => new Damage<Ice>(value),
            EElementalType.Earth => new Damage<Earth>(value),
            EElementalType.Lightning => new Damage<Lightning>(value),
            EElementalType.Nature => new Damage<Nature>(value),
            _ => null,
        };

        public static BaseDamage CreateDamage(DamageBlueprint blueprint) => blueprint.type switch
        {
            EElementalType.Physical => new Damage<Physical>(blueprint.value),
            EElementalType.Fire => new Damage<Fire>(blueprint.value),
            EElementalType.Ice => new Damage<Ice>(blueprint.value),
            EElementalType.Earth => new Damage<Earth>(blueprint.value),
            EElementalType.Lightning => new Damage<Lightning>(blueprint.value),
            EElementalType.Nature => new Damage<Nature>(blueprint.value),
            _ => null,
        };
    }
}