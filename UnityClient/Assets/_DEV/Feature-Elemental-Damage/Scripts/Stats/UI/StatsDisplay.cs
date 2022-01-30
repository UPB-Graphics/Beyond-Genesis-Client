using System.Collections.Generic;
using System.Linq;
using ElementalDamage.Utils;
using UnityEditor;
using UnityEngine;

namespace ElementalDamage.StatManagement
{
    [System.Serializable]
    public class StatIconDictionary : SerializableDictionary<EStatType, Sprite> { }

    [CustomPropertyDrawer(typeof(StatIconDictionary))]
    public class StatIconDictionaryDrawer : SerializableDictionaryPropertyDrawer {}

    [System.Serializable]
    public class StatColorDictionary : SerializableDictionary<EStatType, Color> { }

    [CustomPropertyDrawer(typeof(StatColorDictionary))]
    public class StatColorDictionaryDrawer : SerializableDictionaryPropertyDrawer {}

    public class StatsDisplay : MonoBehaviour
    {
        [SerializeField] private Stats m_Stats;
        [SerializeField] private StatDisplay m_StatDisplayTemplate;
        [SerializeField] private StatIconDictionary m_StatIconDictionary;
        [SerializeField] private StatColorDictionary m_StatColorDictionary;
        
        private List<StatDisplay> m_StatDisplays;

        private void OnValidate()
        {
            if (m_Stats == null)
                m_Stats = GetComponentInParent<Stats>();
            foreach (EStatType statType in System.Enum.GetValues(typeof(EStatType)))
            {
                if (!m_StatColorDictionary.ContainsKey(statType))
                {
                    m_StatColorDictionary[statType] = Random.ColorHSV();
                }

                if (!m_StatIconDictionary.ContainsKey(statType))
                {
                    m_StatIconDictionary[statType] = null;
                }
            }
        }

        private void Start()
        {
            int i = 0;
            m_StatDisplays = GetComponentsInChildren<StatDisplay>().ToList();

            foreach (KeyValuePair<EStatType, BaseStat> statKVP in m_Stats.StatDict)
            {
                if (i >= m_StatDisplays.Count)
                {
                    m_StatDisplays.Add(Instantiate(m_StatDisplayTemplate, transform));
                }

                StatDisplay statDisplay = m_StatDisplays[i++];
                statDisplay.StatColorDictionary = m_StatColorDictionary;
                statDisplay.StatIconDictionary = m_StatIconDictionary;
                statDisplay.Stat = statKVP.Value;
            }
        }
    }
}