using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftingSystem
{
    public abstract class Recipe : SerializedScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _craftingTime;
        [SerializeField] private Dictionary<CraftingMaterial, int> _matsCount;

        public string Name { get { return _name; } }
        public Dictionary<CraftingMaterial, int> Mats { get { return _matsCount; } }

        public float CraftingTime { get => _craftingTime; }
    }
}