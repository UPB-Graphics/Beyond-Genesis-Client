using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftingSystem
{
    public class Anvil : SerializedMonoBehaviour
    {
        [SerializeField] private Blacksmith _blacksmith;
        [SerializeField] private Recipe _ironSword;

        //Replace / Link invetory here
        [SerializeField] Dictionary<CraftingMaterial, int> _mats;

        [Button]
        private void Craft()
        {
            bool canCraft = true;

            foreach (var mat in _ironSword.Mats)
            {
                if (!_mats.ContainsKey(mat.Key))
                {
                    canCraft = false;
                }
                else
                {
                    if (mat.Value > _mats[mat.Key])
                    {
                        canCraft = false;
                    }
                }
            }
            if (canCraft)
            {
                _blacksmith.Craft(_ironSword);

                //Removing some of the materials after crafting is done
                foreach (var mat in _ironSword.Mats)
                {
                    _mats[mat.Key] -= mat.Value;
                }
            }
            else
                Debug.Log("Not enough materials");
        }
    }
}
