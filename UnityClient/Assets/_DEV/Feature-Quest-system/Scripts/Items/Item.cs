using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythical
}

public class Item
{
    public string itemId;
    public string name;
    public ItemRarity rarity;
    
    public Item(string name, ItemRarity rarity)
    {
        itemId = System.Guid.NewGuid().ToString();
        this.name = name;
        this.rarity = rarity;
    }

}
