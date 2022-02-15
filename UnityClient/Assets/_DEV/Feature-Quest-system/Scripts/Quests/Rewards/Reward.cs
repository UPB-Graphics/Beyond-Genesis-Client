using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RewardTypeEnum
{
    RewardMoney,
    RewardItem,
    RewardExp
}

public class Reward
{
    public RewardTypeEnum rewardType;

    public Reward (RewardTypeEnum rewardType)
    {
        this.rewardType = rewardType;
    }
}
