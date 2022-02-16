using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerSkillController : MonoBehaviour
{
    [SerializeField] public SkillBar skillBar;
    [SerializeField] public SkillSlot[] skillSlots;
    [SerializeField] float maxMana = 100;
    [SerializeField] public float currentMana = 100;

    [SerializeField] PlayerSkillObject emptySkill;

    // Start is called before the first frame update
    void Start()
    {
        InitializeSkills();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) skillSlots[0].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha2)) skillSlots[1].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha3)) skillSlots[2].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha4)) skillSlots[3].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha5)) skillSlots[4].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha6)) skillSlots[5].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha7)) skillSlots[6].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha8)) skillSlots[7].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha9)) skillSlots[8].ActivateSkill();
        if (Input.GetKeyDown(KeyCode.Alpha0)) skillSlots[9].ActivateSkill();
    }

    
    // Add skill from skill panel to the first empty skill slot
    public void AssignSkillToSlot(PlayerSkillObject skill)
    {
        foreach(SkillSlot skillSlot in skillSlots)
        {
            if (skillSlot.skill.Equals(emptySkill))
            {
                skillSlot.skill = skill;
                InitializeSkills();
                break;
            }
        }
    }

    // Remove last skill from skill slot
    public void RemoveSkillFromSlot()
    {

        for(int i = skillSlots.Length - 1; i >= 0; i--)
        {
            if (!skillSlots[i].skill.Equals(emptySkill))
            {
                skillSlots[i].skill = emptySkill;
                InitializeSkills();
                break;
            }
        }
    }
      

    void InitializeSkills()
    {
        if (skillSlots.Length > 0)
        {
            for (int i = 0; i < skillSlots.Length; i++)
            {
                skillSlots[i].controller = this;
                skillSlots[i].skill.InitializeSkill();
                skillBar.SetSkillImage(skillSlots[i], i);
            }
        }
    }

    public void ChangeMana(float amount)
    {
        currentMana += amount;
        foreach(SkillSlot skillSlot in skillSlots)
        {
            skillSlot.CheckMana();
        }
    }
}

[System.Serializable]
public class SkillSlot
{
    public PlayerSkillObject skill;
    public bool activable = true;
    public bool enoughMana = true;

    [System.NonSerialized] public PlayerSkillController controller;
    public Image skillSlotImage;
    public void ActivateSkill()
    {
        if (!activable)
        {
            Debug.Log("Recharging!");
        }
        else
        {
            if (controller.currentMana - skill.manaCost < 0)
            {
                Debug.Log("Not enough mana!");
                enoughMana = false;
            }
            else
            {
                controller.ChangeMana(-skill.manaCost);
                Vector3 targetPosition = controller.transform.position + controller.transform.forward * skill.distance;
                skill.ActivateSkill(controller.transform.position, targetPosition);
                controller.StartCoroutine(StartCooldown());
            }
        }

    }
    IEnumerator StartCooldown()
    {
        activable = false;
        float counter = skill.cooldown;
        float counterDecrease = 0.1f;
        while (counter > 0)
        {
            yield return new WaitForSeconds(counterDecrease);
            counter -= counterDecrease;
            skillSlotImage.color = (enoughMana ? Color.white : Color.blue) * (skill.cooldown - counter) / skill.cooldown;
        }
        if (counter <= 0)
        {
            skillSlotImage.color = (enoughMana ? Color.white : Color.blue);
            activable = true;
        }
    }

    public void CheckMana()
    {
        if (controller.currentMana < skill.manaCost)
        {
            enoughMana = false;
            skillSlotImage.color = Color.blue;
        }
        else
        {
            enoughMana = true;
            skillSlotImage.color = Color.white;
        }
    }
}

