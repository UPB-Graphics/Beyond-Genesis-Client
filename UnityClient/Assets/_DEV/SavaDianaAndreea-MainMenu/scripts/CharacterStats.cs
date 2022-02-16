using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth {get; private set;}
    public int speed;
    public int intellect;
    public int wisdom;
    public int strength;
    public int durability;
    public Stat damage;
    public TextMeshProUGUI healthText, speedText, intellectText, wisdomText, strengthText, durabilityText; 
    public Stat armor;
    void Awake () {
        currentHealth = maxHealth;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(10);
        }
        healthText.text = currentHealth.ToString();
        speedText.text = speed.ToString();
        intellectText.text = intellect.ToString();
        wisdomText.text = wisdom.ToString();
        strengthText.text = strength.ToString();
        durabilityText.text = durability.ToString();

    }
    public void TakeDamage(int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes "+ damage);

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        //die
        //overwrite this method
        Debug.Log(transform.name + "dies");
    }
}
