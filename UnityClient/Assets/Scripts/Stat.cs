using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int defaultValue;
    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = defaultValue;
        foreach(int modifier in modifiers)
        {
            finalValue += defaultValue;
        }

        return finalValue;
    }

    public void AddModifier(int amount)
    {
        modifiers.Add(amount);
    }

    public void RemoveModifier(int amount)
    {
        modifiers.Remove(amount);
    }

    public void ClearAllModifiers()
    {
        modifiers.Clear();
    }
}
