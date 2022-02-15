using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    private int enemyId;

    public KillGoal(int enemyId, int amount)
    {
        this.enemyId = enemyId;
        amountToAchieve = (uint)amount;
        currentAmount = 0;

    }

    public override void UpdateCustom()
    {
        goalText = "Kill enemy with id: " + enemyId + ": " + currentAmount + " / " + amountToAchieve;
    }

    void EnemyDied(Enemy enemy)
    {
        if (!completed && enemy.numericId == enemyId)
        {
            currentAmount++;
            Debug.Log("Killed " + currentAmount + " / " + amountToAchieve);
            completed = currentAmount >= amountToAchieve;
            if (completed)
            {
                Debug.Log("Kill goal completed!");
                StopTracking();
            }
        }
    }

    public override void StartTracking()
    {
        EnemyManager.instance.OnEnemyKilledCallback += EnemyDied;
    }

    public override void StopTracking()
    {
        if (EnemyManager.instance.OnEnemyKilledCallback != null)
            EnemyManager.instance.OnEnemyKilledCallback -= EnemyDied;
    }
}
