using UnityEngine;

[System.Serializable]
public class Mana
{
    public int maxMana;
    public int currentMana;
    public int manaRegenAmount; 

    private float timer;

    public int getMaxMana()
    {
        return maxMana;
    }

    public int getCurrentMana()
    {
        return currentMana;
    }

    public void setMaxMana(int value)
    {
        maxMana = value;
    }

    public void setCurrentMana()
    {
        currentMana = maxMana;
    }

    public void substractMana(int amount)
    {
        currentMana -= amount;
    }

    public void regenMana()
    {
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0;
                currentMana += manaRegenAmount;
            }
        }
    }
}
