using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ElementalDamage
{
    public class DemoAttackConfigDisplay : MonoBehaviour
    {
        [SerializeField] private AttackController m_AttackController;
        [SerializeField] private Dropdown m_ElementDropdown;
        [SerializeField] private Text m_DamageValue;

        private void OnValidate()
        {
            if (m_DamageValue == null)
                m_DamageValue = GetComponentInChildren<Text>();
            if (m_ElementDropdown == null)
                m_ElementDropdown = GetComponentInChildren<Dropdown>();
            if (m_AttackController == null)
                m_AttackController = GetComponentInParent<AttackController>();
        }

        private void Start()
        {
            m_ElementDropdown.ClearOptions();
            m_ElementDropdown.AddOptions(System.Enum.GetNames(typeof(EElementalType)).ToList());

            m_ElementDropdown.value = (int)m_AttackController.DamageBP.type;
            m_DamageValue.text = m_AttackController.DamageBP.value.ToString();
        }

        public void Increase()
        {
            int value = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                value *= 5;
            if (Input.GetKey(KeyCode.LeftShift))
                value *= 20;

            m_AttackController.DamageBP.value += value;
        }

        public void Decrease()
        {
            int value = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                value *= 5;
            if (Input.GetKey(KeyCode.LeftShift))
                value *= 20;

            m_AttackController.DamageBP.value -= value;
        }

        public void ChangeElementalType(int element)
        {
            m_AttackController.DamageBP.type = (EElementalType)element;
            m_ElementDropdown.captionText.color = DamageNumbersManager.Instance.ElementalColorDict[m_AttackController.DamageBP.type];
        }
    }
}