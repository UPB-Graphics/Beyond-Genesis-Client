using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using ElementalDamage.Utils;

namespace ElementalDamage
{
    [System.Serializable]
    public class ElementalColorDictionary : SerializableDictionary<EElementalType, Color> {}

    [CustomPropertyDrawer(typeof(ElementalColorDictionary))]
    public class ElementalColorDictionaryDrawer : SerializableDictionaryPropertyDrawer {}

    [System.Serializable]
    public class ElementalCombinationColorDictionary : SerializableDictionary<EElementalCombination, Color> {}

    [CustomPropertyDrawer(typeof(ElementalCombinationColorDictionary))]
    public class ElementalCombinationColorDictionaryDrawer : SerializableDictionaryPropertyDrawer {}

    public class DamageNumbersManager : MonoSingleton<DamageNumbersManager>
    {
        [SerializeField] private int m_MaxCapacity;
        [SerializeField] private DamagePopup m_DamagePopupPrefab;
        public ElementalColorDictionary ElementalColorDict;
        public ElementalCombinationColorDictionary ElementalCombinationColorDict;

        private readonly List<DamagePopup> m_ActiveDamagePopups = new List<DamagePopup>();
        private readonly List<DamagePopup> m_InctiveDamagePopups = new List<DamagePopup>();

        private void OnValidate()
        {
            Debug.Assert(m_DamagePopupPrefab != null, "[DamageNumbersManager] Damage Popup Prefab is null");
        }

        private void OnPopupActiveChanged(bool wasActive, bool isActive, DamagePopup popup)
        {
            if (wasActive)
                m_ActiveDamagePopups.Remove(popup);
            else
                m_InctiveDamagePopups.Remove(popup);

            if (isActive)
                m_ActiveDamagePopups.Add(popup);
            else
                m_InctiveDamagePopups.Add(popup);
        }

        public void SpawnDamagePopup(Vector3 position, BaseDamage damage)
        {
            Vector3 direction = Quaternion.AngleAxis(10.0f * (float)damage.GetElementalType(), Vector3.forward) * Vector3.up;
            DamagePopup popup;
            if (m_InctiveDamagePopups.Count > 0)
            {
                popup = m_InctiveDamagePopups[0];
            }
            else if (m_ActiveDamagePopups.Count >= m_MaxCapacity)
            {
                popup = m_ActiveDamagePopups[0];
            }
            else
            {
                popup = Instantiate(m_DamagePopupPrefab, transform);
                popup.ActiveChanged.AddListener(OnPopupActiveChanged);
            }

            popup.Setup(position, direction, damage.Value, ElementalColorDict[damage.GetElementalType()]);
            
        }

        public void SpawnCombinationPopup(Vector3 position, EElementalCombination combination)
        {
            Vector3 direction = Quaternion.AngleAxis(-10.0f * (float)combination, Vector3.forward) * Vector3.up;
            DamagePopup popup;
            if (m_InctiveDamagePopups.Count > 0)
            {
                popup = m_InctiveDamagePopups[0];
            }
            else if (m_ActiveDamagePopups.Count >= m_MaxCapacity)
            {
                popup = m_ActiveDamagePopups[0];
            }
            else
            {
                popup = Instantiate(m_DamagePopupPrefab, transform);
                popup.ActiveChanged.AddListener(OnPopupActiveChanged);
            }

            popup.Setup(position, direction, System.Enum.GetName(typeof(EElementalCombination), combination), ElementalCombinationColorDict[combination]);
            
        }

        protected override void InternalInit()
        {
            foreach (EElementalType elementalType in System.Enum.GetValues(typeof(EElementalType)))
            {
                if (!ElementalColorDict.ContainsKey(elementalType))
                {
                    ElementalColorDict[elementalType] = Random.ColorHSV();
                }
            }

            foreach (EElementalCombination elementalCombination in System.Enum.GetValues(typeof(EElementalCombination)))
            {
                if (!ElementalCombinationColorDict.ContainsKey(elementalCombination))
                {
                    ElementalCombinationColorDict[elementalCombination] = Random.ColorHSV();
                }
            }
        }

        protected override void InternalOnDestroy()
        {
            foreach(DamagePopup popup in m_ActiveDamagePopups)
            {
                Destroy(popup);
            }

            foreach(DamagePopup popup in m_InctiveDamagePopups)
            {
                Destroy(popup);
            }
        }
    }
}