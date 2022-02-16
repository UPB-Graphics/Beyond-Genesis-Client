using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    [SerializeField] PlayerSkillController controller;
    [SerializeField] SkillDisplay[] skillDisplays;
    [SerializeField] PlayerSkillObject[] playerSkills;
    

    private void Start()
    {
        InitializeSkills();
    }

    // Set the variables for all skill display panels
    public void InitializeSkills()
    {
        for (int i = 0; i < playerSkills.Length; i++)
        {
            skillDisplays[i].InitializeSkillDisplay(controller, playerSkills[i]);
        }
    }
}
