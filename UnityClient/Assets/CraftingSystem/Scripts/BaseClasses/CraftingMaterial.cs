using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CraftingMaterial : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _id;

    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public int Id { get => _id; }
}
