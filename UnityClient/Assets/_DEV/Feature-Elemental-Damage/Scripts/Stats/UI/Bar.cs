using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ElementalDamage.StatManagement
{
    [RequireComponent(typeof(Slider))]
    public abstract class Bar<T> : MonoBehaviour where T : PointStat
    {
        private T m_Stat;
        public T Stat {
            get => m_Stat;
            set {
                if (m_Stat != null)
                    m_Stat.PointValueChanged.RemoveListener(OnValueChanged);

                m_Stat = value;

                if (m_Stat != null)
                    m_Stat.PointValueChanged.AddListener(OnValueChanged);
            }
        }

        [SerializeField] private Slider m_Slider;

        private void OnValidate() {
            if (m_Slider == null)
                m_Slider = GetComponent<Slider>();
        }

        private void OnValueChanged(float value, float maxValue)
        {
            m_Slider.value = Mathf.Clamp01(value / maxValue);
        }
    }
}