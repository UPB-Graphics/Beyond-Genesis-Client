using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMoney : Reward
{
    public float ammount = 0;

    public RewardMoney (float ammount) : base(RewardTypeEnum.RewardMoney)
    {
        this.ammount = ammount;
    }
}
