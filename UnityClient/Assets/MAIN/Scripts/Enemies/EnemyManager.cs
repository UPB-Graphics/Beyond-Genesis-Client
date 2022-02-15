using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public delegate void OnEnemyKilled(Enemy enemy);
    public OnEnemyKilled OnEnemyKilledCallback;

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }
}
