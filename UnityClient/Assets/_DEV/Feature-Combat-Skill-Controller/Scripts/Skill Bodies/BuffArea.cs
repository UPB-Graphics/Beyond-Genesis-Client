using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffArea : SkillBody
{
    public float duration = 3;
    public float buffInterval = 1;
    public string buffedStat = "Health";
    public float buffAmount = 5;

    float durationTimer = 0f;
    float intervalTimer = 1;
    bool intervalTrigger;

    // Update is called once per frame
    public override void Update()
    {
        durationTimer += Time.deltaTime;
        if (durationTimer >= duration) Destroy(gameObject);
       
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= buffInterval)
        {
            intervalTrigger = true;
            intervalTimer = 0;
        }
        else
        {
            intervalTrigger = false;
        }
    }

    public override void Activate(PlayerSkillObject skill, Vector3 _targetPosition)
    {
        duration = skill.duration;
        buffInterval = skill.buffInterval;
        intervalTimer = buffInterval;
        buffedStat = skill.buffedStat;
        buffAmount = skill.buffAmount;
        activated = true;
    }

    public override void Initialize(PlayerSkillObject skill)
    {
        transform.localScale = new Vector3(skill.area, skill.area, skill.area);
    }

    private void OnTriggerStay(Collider other)
    {
        if(buffInterval > 0 && intervalTrigger)
        {
            // BUFF CODE for interval use
        }
        else if (buffInterval <= 0 && intervalTimer == 0)
        {
            // BUFF CODE for one time use
        }
    }
}
