using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : SkillBody
{
    Vector3 targetPosition;
    float projectileSpeed = 1;

    Vector3 movementVector;
    float lastDistance = 1000;

    private void Awake()
    {
        //projectileSpeed = 50;
    }

    public override void Update()
    {
        // Move projectile towards destination
        if (activated)
        {
            transform.position += movementVector * Time.deltaTime;
            float currentDistance = Vector3.Distance(transform.position, targetPosition);

            if (currentDistance > lastDistance)
            {
                Destroy(gameObject);
            }

            lastDistance = currentDistance;
        }

    }

    public override void Activate(PlayerSkillObject skill, Vector3 _targetPosition)
    {
        projectileSpeed = skill.projectileSpeed;
        targetPosition = _targetPosition;
        movementVector = (targetPosition - transform.position).normalized * projectileSpeed;

        activated = true;
    }

    public override void Initialize(PlayerSkillObject skill)
    {
        transform.localScale = new Vector3(skill.width, skill.height, skill.width);
    }

    private void OnTriggerEnter(Collider other)
    {
        // DAMAGE CODE
    }

}
