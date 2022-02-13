using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePet : BasePet
{
    public float orbitDistance;
    public float orbitPeriod;
    public float followSpeed;
    public ParticleSystem ps;
    float angle = 0;
    public override void DoFollow(float fixedDT)
    {
        Vector3 targetPosition;
        targetPosition = ObjectToFollow.position;
        targetPosition += new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad) * orbitDistance, 0, Mathf.Cos(angle * Mathf.Deg2Rad) * orbitDistance);
        angle += (360.0f/orbitPeriod) * fixedDT;
        if(((targetPosition - transform.position).normalized * followSpeed * fixedDT).magnitude < (targetPosition - transform.position).magnitude)
        {
            transform.position += (targetPosition - transform.position).normalized * followSpeed * fixedDT;
        } else
        {
            transform.position += (targetPosition - transform.position);
        }
    }

    public override float DoPetAction(float action)
    {
        ps.startColor = Color.HSVToRGB(action, 1, 1);
        return Random.Range(0.4f, 1.6f);
    }
}
