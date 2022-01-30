using UnityEngine;
using ElementalDamage.StatManagement;

namespace ElementalDamage
{
    public abstract class ADamageable : MonoBehaviour 
    {
        public Element AfflictedBy = null;

        public virtual void OnHit(BaseDamage damage)
        {
            if (AfflictedBy != null)
            {
                EElementalCombination combination = AfflictedBy.GetCombination(damage.GetElementalType());
                if (combination != EElementalCombination.None)
                {
                    DamageNumbersManager.Instance.SpawnCombinationPopup(transform.position, combination);
                    AfflictedBy = null;
                    return;
                }
            }

            AfflictedBy = damage.GetElement();
        }
    }
}