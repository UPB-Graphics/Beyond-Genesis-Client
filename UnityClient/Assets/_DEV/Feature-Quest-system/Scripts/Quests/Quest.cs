using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest
{
    public List<Goal> Goals = new List<Goal>();
    public List<Reward> Rewards = new List<Reward>();
    public bool completed;
    public string questName;
    public string description;

    public Quest(List<Goal> Goals, List<Reward> Rewards, string questName, string description)
    {
        this.Goals = Goals;
        this.Rewards = Rewards;
        this.questName = questName;
        this.description = description;
    }

    public void ActivateGoals()
    {
        foreach (Goal goal in Goals)
        {
            goal.StartTracking();
        }
    }

    public void DeactivateGoals()
    {
        foreach (Goal goal in Goals)
        {
            goal.StopTracking();
        }
    }

    public void CheckGoals()
    {
        completed = Goals.All(g => g.completed); //questul este gata cand toate obiectivele sunt complete
        if(completed)
        {
            DeactivateGoals();
            GiveReward();
        }
    }

    public void GiveReward()
    {
        foreach (var reward in Rewards)
        {
            switch(reward.rewardType)
            {
                case RewardTypeEnum.RewardMoney:
                    MoneyManager.instance.AddMoney(((RewardMoney)reward).ammount);
                    break;
                case RewardTypeEnum.RewardItem:
                    ItemManager.instance.AddItem(((RewardItem)reward).item);
                    break;
                case RewardTypeEnum.RewardExp:
                    ExpManager.instance.AddExp(((RewardExp)reward).ammount);
                    break;
                default:
                    break;
            }
        }
    }
}
