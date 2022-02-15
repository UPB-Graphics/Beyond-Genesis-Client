using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : Goal
{
    private Vector3 poz;
    private bool tracking = false;

    public MoveGoal(Vector3 poz)
    {

    }


    public override void UpdateCustom()
    {
        goalText = "Go to " + poz.ToString();
        if (tracking)
        {
            if (Vector3.Distance(PlayerManager.instance.poz, poz) <= 2.0f)
            {
                completed = true;
            }
        }
    }

    public override void StartTracking()
    {
        tracking = true;
    }

    public override void StopTracking()
    {
        tracking = false;
    }
}
