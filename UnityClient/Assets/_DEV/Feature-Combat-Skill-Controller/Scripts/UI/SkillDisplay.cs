using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillDisplay : MonoBehaviour
{
    public Image skillImage;
    public TextMeshProUGUI text;
    public Button skillButton;
    public PlayerSkillObject skill;
    public PlayerSkillController controller;

    // Set Skill Display variables
    public void InitializeSkillDisplay(PlayerSkillController _controller, PlayerSkillObject _skillObject)
    {
        skillImage.sprite = _skillObject.image;
        text.text = _skillObject.skillName;
        skill = _skillObject;
        controller = _controller;
        skillButton.onClick.RemoveAllListeners();
        skillButton.onClick.AddListener(() => { controller.AssignSkillToSlot(skill); CheckInUse(); });
        CheckInUse();
    }

    // Disable Button if the skill is already on the skill bar
    void CheckInUse()
    {
        skillButton.interactable = true;

        foreach (SkillSlot skillSlot in controller.skillSlots)
        {
            if (skill.Equals(skillSlot.skill))
            {
                skillButton.interactable = false;
                break;
            }
        }
    }
}
