using UnityEngine;
using UnityEngine.UI;

namespace ElementalDamage.StatManagement
{
    public class StatDisplay : MonoBehaviour
    {
        [SerializeField] private Image StatIcon;
        [SerializeField] private Text StatText;
        [SerializeField] private Text StatValueText;

        public StatColorDictionary StatColorDictionary { private get; set; }
        public StatIconDictionary StatIconDictionary { private get; set; }

        [SerializeField]
        private BaseStat m_Stat;
        public BaseStat Stat {
            get => m_Stat;
            set {
                if (m_Stat != value)
                {
                    if (m_Stat != null)
                        Clear(m_Stat);
                    m_Stat = value;
                    Set(m_Stat);
                    
                }
            }
        }

        private void OnValidate()
        {
            Debug.Assert(StatIcon != null);
            Debug.Assert(StatText != null);
            Debug.Assert(StatValueText != null);
        }

        private void Clear(BaseStat stat)
        {
            if (stat == null)
                return;

            if (stat is PointStat pointStat)
                pointStat.PointValueChanged.RemoveListener(UpdatePointValue);
            else
                stat.ValueChanged.RemoveListener(UpdateValue);

            StatText.color = Color.black;
            StatValueText.color = Color.black;
            StatText.text = "";
            StatValueText.text = "";
            StatIcon.sprite = null;
            StatIcon.color = Vector4.one;
        }

        private void Set(BaseStat stat)
        {
            if (stat == null)
                return;

            if (stat is PointStat pointStat)
                pointStat.PointValueChanged.AddListener(UpdatePointValue);
            else
                stat.ValueChanged.AddListener(UpdateValue);

            StatText.color = StatColorDictionary[stat.GetStatType()];
            StatValueText.color = StatColorDictionary[stat.GetStatType()];
            StatIcon.sprite = StatIconDictionary[stat.GetStatType()];
            StatIcon.color = StatColorDictionary[stat.GetStatType()];
            StatText.text = stat.GetDescription();
            StatValueText.text = stat.GetValueString();
        }

        private void UpdateValue(float value)
        {
            StatText.text = m_Stat.GetDescription();
            StatValueText.text = m_Stat.GetValueString();
        }

        private void UpdatePointValue(float value, float maxValue)
        {
            StatText.text = m_Stat.GetDescription();
            StatValueText.text = m_Stat.GetValueString();
        }
    }
}