using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCaster : MonoBehaviour
{
    public bool inFireMode = false;

    public int skillDamage = 10;
    public float skillDuration = 2.0f;
    public float skillFireRate = 2.0f;

    public float skillAoeRadius = 3.0f;
    public float skillAoeHeight = 100f;
    public float skillAnimationDuration = 0.1f;

    public GameObject skillAreaPrefab;

    public LayerMask skillAreaMask;
    public LayerMask skillTargetMask;
    public Color skillHitColor;

    private GameObject skillArea;
    private Color skillDefaultColor;
    private Renderer skillRenderer;

    private Animator animator;



    private Vector3 GetTargetPosition()
    {
        RaycastHit _hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit, 1000, skillAreaMask))
        {
            return _hit.point;
        }
        else
        {
            Debug.LogError("Mouse position doesn't intersect plane!");
            return transform.position + transform.forward * 6.0f;
        }
    }

    void StopShooting()
    {
        CancelInvoke("Shoot");
    }

    public void ResetColor()
    {
        skillRenderer.material.color = skillDefaultColor;
    }

    public void ChangeColor(Color color, float resetDelay)
    {
        skillRenderer.material.color = color;
        Invoke("ResetColor", resetDelay);
    }

    void Shoot()
    {
        if (skillArea != null)
        {
            Vector3 _damageCenter = skillArea.transform.position;
            _damageCenter.y = skillAoeHeight / 2;

            // use box to simulate height
            Collider[] affectedEnemies = Physics.OverlapBox(_damageCenter, new Vector3(skillAoeRadius, skillAoeHeight / 2, skillAoeRadius), Quaternion.identity, skillTargetMask);

            foreach (Collider enemyCollider in affectedEnemies)
            {
                Enemy _enemy = enemyCollider.gameObject.GetComponent<Enemy>();

                if (_enemy != null)
                {
                    Vector3 _enemyPosition = _enemy.transform.position;
                    
                    // Project enemypos and damageCenter on the same plane
                    _enemyPosition.y = _damageCenter.y;

                    if (Vector3.Distance(_enemyPosition, _damageCenter) <= skillAoeRadius)
                    {
                        _enemy.TakeDamage(skillDamage);
                        //_enemy.ChangeColor(Color.red, skillAnimationDuration);
                    }
                }
            }

            ChangeColor(skillHitColor, skillAnimationDuration);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!inFireMode)
            {
                inFireMode = true;
                animator.SetTrigger("BeginShoot");

                Vector3 _target = GetTargetPosition();
                transform.LookAt(_target);

                skillArea = Instantiate(skillAreaPrefab, _target, Quaternion.identity);

                skillRenderer = skillArea.GetComponent<Renderer>();
                skillDefaultColor = skillRenderer.material.color;

                float yScale = skillArea.transform.localScale.y;
                skillArea.transform.localScale = new Vector3(skillAoeRadius * 2, yScale, skillAoeRadius * 2);
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            inFireMode = false;
            animator.SetTrigger("EndShoot");

            if (skillArea != null)
            {
                if (skillFireRate > 0.0f)
                {
                    InvokeRepeating("Shoot", 0.0f, 1f / skillFireRate);
                    Invoke("StopShooting", skillDuration);
                }

                Destroy(skillArea, skillDuration);
            }
        }

        if (inFireMode)
        {
            if (skillArea != null)
            {
                Vector3 _target = GetTargetPosition();

                skillArea.transform.position = _target;
                transform.LookAt(_target);
            }
                
        }
    }
}
