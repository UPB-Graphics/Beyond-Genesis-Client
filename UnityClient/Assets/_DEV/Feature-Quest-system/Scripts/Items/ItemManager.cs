using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public List<Item> Items = new List<Item>();
    public Dictionary<ItemRarity, float> rarityTable = new Dictionary<ItemRarity, float>() {
        { ItemRarity.Common, 0.8f },
        { ItemRarity.Uncommon, 0.15f },
        { ItemRarity.Rare, 0.04f },
        { ItemRarity.Epic, 0.005f },
        { ItemRarity.Legendary, 0.0004f },
        { ItemRarity.Mythical, 0.0001f }
    };

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(string itemId)
    {
        Item toRemove = null;

        foreach (var item in Items)
        {
            if (item.itemId == itemId)
            {
                toRemove = item;
                break;
            }
        }

        if (toRemove != null)
        {
            Items.Remove(toRemove);
        }
    }
}
