using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree; 
public class Skill : MonoBehaviour 
{
    public int id; 
    public TMP_Text TitleText;
    public TMP_Text DescriptionText; 
    public int[] ConnectedSkills; 

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}\n{skillTree.SkillNames[id]}";
        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}\nCost: {skillTree.SkillPoint}/1 SP";

        GetComponent<Image>().color = skillTree.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.yellow 
            : skillTree.SkillPoint >= 1 ? Color.green : Color.white; 

        foreach (var connectedSkill in ConnectedSkills) 
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.SkillLevels[id] > 0);
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.SkillLevels[id] > 0); 
        }
            
    }
    
    public void Buy()
    { 
        if (skillTree.SkillPoint < 1 || skillTree.SkillLevels[id] >= skillTree.SkillCaps[id]) return;
        if (skillTree.SkillLevels[id] == skillTree.SkillCaps[id]-1)
        {
            if (id == 0)
            {
                skillTree.Intelligence += skillTree.int_val;
                skillTree.Strength += skillTree.str_val;
            }
            else if (id == 1)
            {
                skillTree.Dexterity += skillTree.dex_val;
            }
            else if (id == 2)
            {
                skillTree.Armour += skillTree.arm_val;
            }
            else if (id == 3)
            {
                skillTree.Vitality += skillTree.vit_val;
                skillTree.Strength += skillTree.str_val;
            }
            else if (id == 4)
            {
                skillTree.Dexterity += skillTree.dex_val-2;
                skillTree.Vitality += skillTree.vit_val-5;
            }
            else if (id == 5)
            {
                skillTree.Attack += skillTree.Armour * skillTree.arm_per/100;
            }
            else if (id == 6)
            {
                skillTree.Intelligence += skillTree.int_val+5;
                skillTree.Vitality += skillTree.vit_val;
            }
            else if (id == 7)
            {
                skillTree.Armour += skillTree.arm_val+10;
                skillTree.Strength += skillTree.str_val+5;
            }
            skillTree.HP = 10 * skillTree.Vitality;
        }
        skillTree.SkillPoint --;
        skillTree.SkillLevels[id]++;
        skillTree.UpdateAllSkillUI();
    }

}