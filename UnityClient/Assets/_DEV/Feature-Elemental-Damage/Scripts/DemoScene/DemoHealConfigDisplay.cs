using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using ElementalDamage.StatManagement;

namespace ElementalDamage
{
    public class DemoHealConfigDisplay : MonoBehaviour
    {
        [SerializeField] private float m_HealValue;
        [SerializeField] private Text m_HealValueText;
        [SerializeField] private Stats m_Stats;

        private void OnValidate()
        {
            if (m_HealValueText == null)
                m_HealValueText = GetComponentInChildren<Text>();
            if (m_Stats == null)
                m_Stats = GetComponentInParent<Stats>();
        }

        private void Start()
        {

            m_HealValueText.text = m_HealValue.ToString();
        }

        public void Increase()
        {
            int value = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                value *= 5;
            else if (Input.GetKey(KeyCode.LeftShift))
                value *= 20;
            else
                value *= 1;

            m_HealValue += value;
        }

        public void Decrease()
        {
            int value = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                value *= 5;
            else if (Input.GetKey(KeyCode.LeftShift))
                value *= 20;
            else
                value *= 1;

            m_HealValue -= value;
        }

        public void Heal()
        {
            m_Stats.ApplyEffect(EStatType.Health, m_HealValue);
        }
    }
}