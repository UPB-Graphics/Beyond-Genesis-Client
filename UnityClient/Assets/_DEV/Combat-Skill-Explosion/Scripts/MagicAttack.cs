using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MagicAttack : MonoBehaviour
{
    public Transform attackOrigin;
    public LayerMask enemyLayer;
    public GameObject particles;
    public Vector3 spellSize;

    public void StartAttack()
    {
        GameObject ps = Instantiate(particles, attackOrigin);
        Destroy(ps, particles.GetComponent<ParticleSystem>().main.duration);
        
        Collider[] colliders = Physics.OverlapBox(attackOrigin.position, spellSize / 2, attackOrigin.rotation, enemyLayer);

        foreach (var collider in colliders)
        {
            Debug.Log(collider);
            // Logica de atac (aplica daune, efecte negative etc.)
        }

    }
}
