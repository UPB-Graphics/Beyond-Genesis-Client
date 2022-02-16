using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBody : MonoBehaviour
{
    // This is the parent class for the "body" of the skills - it contains a collider and it's effect
    public bool activated;
    public abstract void Update();

    public abstract void Activate(PlayerSkillObject skill, Vector3 _targetPosition);
    public abstract void Initialize(PlayerSkillObject skill);
}
