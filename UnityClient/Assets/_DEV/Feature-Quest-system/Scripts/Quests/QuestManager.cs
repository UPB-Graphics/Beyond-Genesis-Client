using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> Quests = new List<Quest>();
    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }

    // Testing purposes, adds a quest and renders it to the UI.
    private void Start()
    {
        KillGoal g = new KillGoal(1, 100);
        MoveGoal mg = new MoveGoal(new Vector3(0, 0, 0));
        RewardExp re = new RewardExp(10f);
        RewardMoney rm = new RewardMoney(10f);
        Quest q = new Quest(new List<Goal>() { g, mg }, new List<Reward>() { re, rm }, "Test", "bla");

        AddQuest(q);
    }

    void Update()
    {
        foreach (var quest in Quests)
        {
            foreach (var goal in quest.Goals)
            {
                goal.UpdateCustom();
            }
            quest.CheckGoals();
        }
    }

    public void AddQuest(List<Goal> Goals, List<Reward> Rewards, string questName, string description)
    {
        Quest quest = new Quest(Goals, Rewards, questName, description);
        quest.ActivateGoals();
        Quests.Add(quest);
        UiManager.instance.AddQuest(quest);
    }

    public void AddQuest(Quest quest)
    {
        quest.ActivateGoals();
        Quests.Add(quest);
        UiManager.instance.AddQuest(quest);
    }
}
