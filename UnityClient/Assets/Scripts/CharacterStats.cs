using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public Health hp;
    public Level level;
    public Mana mana;

    public Stat damage;
    public Stat armor;
    public Stat agility;
    public Stat attackRange;

    [Header("Bars stats")]
    public StatBar healthBar;
    public StatBar manaBar;
    public StatBar levelBar;

    [Header("Text stats")]
    public Text maxHP;
    public Text currentHP;
    public Text maxMana;
    public Text currentMana;
    public Text targetXP;
    public Text currentXP;
    public Text currentLvl;

    public TextMeshProUGUI currentDamage;
    public TextMeshProUGUI currentArmor;
    public TextMeshProUGUI currentAgility;
    public TextMeshProUGUI currentAttackRange;

    [Header("Hidden info")]
    public GameObject hiddenInfo;


    private void Start()
    {
        healthBar.SetMaxValue(hp.getMaxHP());
        manaBar.SetMaxValue(mana.getMaxMana());

        maxHP.text = hp.getMaxHP().ToString();
        maxMana.text = mana.getMaxMana().ToString();
    }

    private void Update()
    {
        //comment the following after finishing testing
        if (Input.GetKeyDown("u"))
        {
            hp.damageCharacter(50, 10);
        }
        if (Input.GetKeyDown("h"))
        {
            hp.healCharacter(30);
        }
        if (Input.GetKeyDown("i"))
        {
            mana.substractMana(10);
        }
        if (Input.GetKeyDown("o"))
        {
            level.IncreaseXp(5);
        }

        //leave them be, ok?
        mana.regenMana();
        healthBar.SetValue(hp.getCurrentHP());
        manaBar.SetValue(mana.getCurrentMana());

        levelBar.SetMaxValue(level.GetXpTarget());
        levelBar.SetValue(level.GetXpValue());

        currentHP.text = hp.getCurrentHP().ToString();
        currentMana.text = mana.getCurrentMana().ToString();
        targetXP.text = level.GetXpTarget().ToString();
        currentXP.text = level.GetXpValue().ToString();
        currentLvl.text = level.GetLevel().ToString();

        currentDamage.text = damage.GetValue().ToString();
        currentArmor.text = armor.GetValue().ToString();
        currentAgility.text = agility.GetValue().ToString();
        currentAttackRange.text = attackRange.GetValue().ToString();
    }

    public int GetLevelValue()
    {
        return level.GetLevel();
    }

    public int GetXpValue()
    {
        return level.GetXpValue();
    }

    public void AddXp(int amount)
    {
        level.IncreaseXp(amount);
    }

    public void SetMaximumHP(int amount)
    {
        hp.setMaxHP(amount);
    }

    public void SetStartingHP()
    {
        hp.setCurrentHP();
    }

    public void SetMaximumMana(int amount)
    {
        mana.setMaxMana(amount);
    }

    public void SetStartingMana()
    {
        mana.setCurrentMana();
    }

    public void CloseHiddenInfo()
    {
        hiddenInfo.SetActive(false);
    }

    public void ShowHiddenInfo()
    {
        hiddenInfo.SetActive(true);
    }
}
