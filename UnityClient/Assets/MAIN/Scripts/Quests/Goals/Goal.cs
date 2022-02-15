using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public bool completed;
    public uint currentAmount;
    public uint amountToAchieve;
    public string goalText;

    public virtual void StartTracking()
    {
        throw new System.NotImplementedException();
    }

    public virtual void StopTracking()
    {
        throw new System.NotImplementedException();
    }

    public virtual void UpdateCustom()
    {
        throw new System.NotImplementedException();
    }
}
