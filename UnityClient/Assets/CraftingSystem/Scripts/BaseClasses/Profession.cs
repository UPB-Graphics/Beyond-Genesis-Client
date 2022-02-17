using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftingSystem
{
    public abstract class Profession : ScriptableObject
    {
        //We keep track of all the recipies here and on the player we could make available
        //just the ones that they learned ( same can be done with any profession created)

        //If a recipie should be removed it just needs to be removed from the list 
        [SerializeField] protected List<Recipe> recipies;

        public virtual void Craft(Recipe recipe)
        {
            Debug.Log("Crafted " + recipe.Name);
        }
    }
}
