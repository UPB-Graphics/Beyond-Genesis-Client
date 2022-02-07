using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth = 0;

    public bool isAlive = true;
    public bool resetHealthOnDeath = true;

    public float healthResetDelay = 0.2f;
    
    [SerializeField]
    private RectTransform healthFill;

    private Color defaultColor;
    private Renderer renderer;

    public float GetHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }

    public void ResetHealth()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    public void ResetColor()
    {
        renderer.material.color = defaultColor;
    }

    public void ChangeColor(Color color, float resetDelay)
    {
        renderer.material.color = color;
        Invoke("ResetColor", resetDelay);
    }

    public void TakeDamage(int value)
    {
        if (currentHealth > 0)
        {
            currentHealth -= value;
            healthFill.localScale = new Vector3(GetHealthPercentage(), 1f, 1f);
        }
        else
        {
            isAlive = false;
            
            if(resetHealthOnDeath)
                Invoke("ResetHealth", healthResetDelay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;

        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
