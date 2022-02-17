using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int money;
    public Text moneyTextUI;
    
    public void Start()
    {
        moneyTextUI.text=""+money;

    }
    public void PayGoods(int price)
    {
        if(money + price > 0) 
        {
            money-=price;
            moneyTextUI.text=""+money;
        }
    }

}
