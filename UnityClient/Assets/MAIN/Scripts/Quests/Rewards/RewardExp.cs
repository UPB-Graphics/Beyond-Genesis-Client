using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardExp : Reward
{
    public float ammount;

    public RewardExp(float ammount) : base(RewardTypeEnum.RewardExp)
    {
        this.ammount = ammount;
    }
}
