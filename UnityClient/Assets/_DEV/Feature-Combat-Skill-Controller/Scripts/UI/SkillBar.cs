using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    [SerializeField] Image[] skillSlotImages;

    public void SetSkillImage(SkillSlot skillSlot, int position)
    {
        skillSlotImages[position].sprite = skillSlot.skill.image;
        skillSlot.skillSlotImage = skillSlotImages[position];
    }
}
