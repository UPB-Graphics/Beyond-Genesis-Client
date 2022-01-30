using UnityEngine;
using UnityEngine.Events;

namespace ElementalDamage.StatManagement
{
    [System.Serializable]
    public class Mana : PointStat
    {
        public override string GetDescription() => "MP";
        public override EStatType GetStatType() => EStatType.Mana;
    }
}