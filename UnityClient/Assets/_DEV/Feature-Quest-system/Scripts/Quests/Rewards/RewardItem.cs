using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardItem : Reward
{
    public Item item;

    public RewardItem(Item item) : base(RewardTypeEnum.RewardItem)
    {
        this.item = item;
    }
}
