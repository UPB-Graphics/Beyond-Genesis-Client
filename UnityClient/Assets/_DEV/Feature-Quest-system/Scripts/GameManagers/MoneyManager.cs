using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    private float moneyAmmount;

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void AddMoney(float ammount)
    {
        moneyAmmount += ammount;
    }

    public int RemoveMoney (float ammount)
    {
        if (moneyAmmount <= ammount)
        {
            return -1;
        } else
        {
            moneyAmmount -= ammount;
            return 1;
        }
    }

    public float GetMoney()
    {
        return moneyAmmount;
    }
}
