using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxValue(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetValue(int amount)
    {
        slider.value = amount;
    }
}
