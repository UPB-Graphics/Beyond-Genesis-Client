using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Ranged,
    Melee
}

public class Enemy
{
    public string enemyId;
    public int numericId;
    public string name;
    public float health;
    public EnemyType type;

    public Enemy(string name, float health, EnemyType type)
    {
        enemyId = System.Guid.NewGuid().ToString();
        this.name = name;
        this.health = health;
        this.type = type;
    }

    public void Kill()
    {
        EnemyManager.instance.OnEnemyKilledCallback?.Invoke(this);
    }
}
