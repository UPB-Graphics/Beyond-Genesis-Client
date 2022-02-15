using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPrefabHelper : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI goalsAndRewardsText;
    public Quest quest = null;


    private void Update()
    {
        if (quest != null)
        {
            titleText.text = quest.questName;
            goalsAndRewardsText.text = "Goals: \n";
            foreach (var goal in quest.Goals)
            {
                goalsAndRewardsText.text += goal.goalText + "\n";
            }

            goalsAndRewardsText.text += "Rewards: \n";
            foreach (var reward in quest.Rewards)
            {
                switch (reward.rewardType)
                {
                    case RewardTypeEnum.RewardMoney:
                        goalsAndRewardsText.text += "Money: " + ((RewardMoney)reward).ammount + "\n";
                        break;
                    case RewardTypeEnum.RewardExp:
                        goalsAndRewardsText.text += "Exp: " + ((RewardExp)reward).ammount + "\n";
                        break;
                    case RewardTypeEnum.RewardItem:
                        goalsAndRewardsText.text += "Item: " + ((RewardItem)reward).item.name + "\n";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
