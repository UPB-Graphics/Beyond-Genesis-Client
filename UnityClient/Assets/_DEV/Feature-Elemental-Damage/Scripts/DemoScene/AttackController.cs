using UnityEngine;

namespace ElementalDamage
{
    public class AttackController : MonoBehaviour
    {
        public DamageBlueprint DamageBP;

        public ADamageable Target;

        public void Attack()
        {
            Target.OnHit(DamageBP.CreateDamage());
        }
    }
}