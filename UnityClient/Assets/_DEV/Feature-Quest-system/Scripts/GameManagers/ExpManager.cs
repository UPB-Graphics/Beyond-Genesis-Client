using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public static ExpManager instance;
    private float expAmmount;

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void AddExp(float ammount)
    {
        expAmmount += ammount;
    }

    public float GetExp()
    {
        return expAmmount;
    }
}
