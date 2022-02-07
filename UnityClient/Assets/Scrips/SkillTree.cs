using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels;
    public int[] SkillCaps;

    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<Skill> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public TMP_Text HP_stat;
    public TMP_Text Att_stat;
    public TMP_Text Arm_stat;
    public TMP_Text Int_stat;
    public TMP_Text Dex_stat;
    public TMP_Text Vit_stat;
    public TMP_Text Str_stat;

    public int SkillPoint;
    public int Strength;
    public int Intelligence;
    public int Armour;
    public int HP;
    public int Vitality;
    public int Dexterity;
    public int Attack;

    public int str_val, int_val, arm_val, dex_val, vit_val, arm_per;

    [System.Obsolete]
    private void Start()
    {

        str_val = Random.RandomRange(3, 7);
        int_val = Random.RandomRange(8, 12);
        arm_val = Random.RandomRange(8, 12);
        dex_val = Random.RandomRange(3, 7);
        vit_val = Random.RandomRange(8, 12);
        arm_per = Random.RandomRange(45, 60);

        SkillPoint = 20;
        SkillLevels = new int[8];
        SkillCaps = new[] { 2, 3, 4, 3, 2, 5, 5, 5 };

        SkillNames = new[] { "Way of the warrior", "Fending", "Prismatic skin", "Born to fight", "Unwavering stance", "Command of steel", "Master of Mana", "Heart of the Warrior" };

        SkillDescriptions = new[]
        {
            $"+{int_val} Intelligence\n+{str_val} Strength",
            $"+{dex_val} Dexterity",
            $"+{arm_val} Armour",
            $"+{vit_val} Vitality\n+{str_val} Strength",
            $"+{dex_val-2} Dexterity\n+{vit_val-5} Vitality",
            $"{arm_per}% Armour converted to Attack",
            $"+{int_val+5} Intelligence\n+{vit_val} Vitality",
            $"+{arm_val+10} Armour\n+{str_val+5} Strength"
        };

        //statusul caracterului
        Strength = 15;
        Intelligence = 10;
        Armour = 20;
        HP = 100;
        Vitality = 10;
        Dexterity = 15;
        Attack = 30;
        //character stats closed

        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>())
            SkillList.Add(skill);

        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>())
            ConnectorList.Add(connector.gameObject);

        for (var i = 0; i < SkillList.Count; i++)
            SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] { 1, 3 };
        SkillList[1].ConnectedSkills = new[] { 2 };
        SkillList[2].ConnectedSkills = new[] { 4, 5 };
        SkillList[4].ConnectedSkills = new[] { 6, 7 };

        UpdateAllSkillUI();
    }

    public void UpdateAllSkillUI()
    {
        foreach (var skill in SkillList)
            skill.UpdateUI();

        Str_stat.text = "STR: " + Strength;
        HP_stat.text = "HP: " + HP;
        Int_stat.text = "INT: " + Intelligence;
        Dex_stat.text = "DEX: " + Dexterity;
        Arm_stat.text = "ARM: " + Armour;
        Vit_stat.text = "VIT: " + Vitality;
        Att_stat.text = "ATT: " + Attack;
    }
}