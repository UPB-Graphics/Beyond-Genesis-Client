using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSkill", menuName = "ScriptableObjects/PlayerSkill", order = 1)]

public class PlayerSkillObject : ScriptableObject
{
    [Header("Standard  tings")]
    [Tooltip("Skill name")] public string skillName = "New skill";
    //[Tooltip("Skill type. Feel free to add new types")] public SkillType skillType = SkillType.Projectile;
    [Tooltip("Mana cost. Needs character implemented first")] public float manaCost = 0;
    [Tooltip("Cooldown")] public float cooldown = 3;
    [Tooltip("Channeling time")] public float channelingTime = 0;
    [Tooltip("Character can be interrupted while channeling")] public bool interruptable = false;
    public Sprite image;

    [Tooltip("The skill body. At the moment it can be a projectile or a buff area.")] public SkillBody skillBody;

    [Tooltip("Particle played while player is channeling")] public ParticleSystem channelingParticleSystem;

    //public enum SkillType { Projectile, Buff};

    [Header("Only For Projectiles")]
    [Tooltip("Projectile damage. Needs enemy implemented first")] public float damageMultiplier = 1;
    [Tooltip("Projectile width")] public float width = 1;
    [Tooltip("Projectile height")] public float height = 2;
    [Tooltip("Projectile travel distance")] public float distance = 10;
    [Tooltip("Projectile speed")] public float projectileSpeed = 1;

    [Header("Only For Buffs")]
    [Tooltip("Buff body AOE")] public float area = 5;
    [Tooltip("Buff body duration (not the duration of modified stats)")]  public float duration = 3;
    [Tooltip("Interval to trigger buff every x seconds while active")] public float buffInterval = 1;
    [Tooltip("Buffed stat. Needs character implemented first")] public string buffedStat = "Health";
    [Tooltip("Buffed stat amount. Needs character implemented first")] public float buffAmount = 5; 


    public void InitializeSkill()
    {
        skillBody.Initialize(this);
    }

    public void ActivateSkill(Vector3 _currentPosition, Vector3 _targetPosition)
    {
        SkillBody sb = Instantiate(skillBody, _currentPosition, Quaternion.identity);
        sb.Activate(this, _targetPosition);
    }
}
