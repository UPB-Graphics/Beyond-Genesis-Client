using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health
{
    public int maxHP;
    public int currentHP;

    public int getMaxHP()
    {
        return maxHP;
    }

    public int getCurrentHP()
    {
        return currentHP;
    }

    public void setMaxHP(int value)
    {
        maxHP = value;
    }

    public void setCurrentHP()
    {
        currentHP = maxHP;
    }

    public void damageCharacter(int damage, int armor)
    {
        currentHP -= (int)(damage - (damage * armor / 100));
        if (currentHP <= 0)
        {
            currentHP = 0;

        }
    }

    public void healCharacter(int value)
    {
        currentHP += value;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
