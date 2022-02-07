using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int currentLevel = 0;
    public int xp = 0;
    public List<int> xpTargets = new List<int>();


    public int GetXpValue()
    {
        return xp;
    }

    public int GetXpTarget()
    {
        if (currentLevel < GetMaxLevel())
        {
            return xpTargets[currentLevel];
        }

        return 0;
    }

    public void IncreaseXp(int amount)
    {
        xp += amount;
        while ((currentLevel < GetMaxLevel()) && (xp >= GetXpTarget()))
        {
            xp -= GetXpTarget();
            IncreaseLevel();
        }

        if (currentLevel == GetMaxLevel())
        {
            xp = 0;
        }
    }

    public void DecreaseXp(int amount)
    {
        xp -= amount;
        if (xp < 0)
        {
            xp = 0;
        }
    }

    public void ResetXp()
    {
        xp = 0;
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetMaxLevel()
    {
        return xpTargets.Count;
    }

    public void IncreaseLevel()
    {
        if (currentLevel < GetMaxLevel())
        {
            currentLevel += 1;
        }
    }

    public void ResetLevel()
    {
        currentLevel = 1;
    }

}
