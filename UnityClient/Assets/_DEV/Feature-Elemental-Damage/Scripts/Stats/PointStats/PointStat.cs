using UnityEngine;
using UnityEngine.Events;

namespace ElementalDamage.StatManagement
{
    [System.Serializable]
    public abstract class PointStat : BaseStat, IRegenerable
    {
        [SerializeField] protected float m_MaxValue;
        public float MaxValue {
            get => m_MaxValue;
            set {
                if (value != m_MaxValue)
                {
                    m_MaxValue = value;
                    if (m_MaxValue < Value)
                    {
                        Value = m_MaxValue;
                    }
                    else
                    {
                        PointValueChanged.Invoke(m_Value, m_MaxValue);
                    }
                }
                
            }
        }

        public override float Value {
            get => m_Value;
            set {
                value = Mathf.Clamp(value, 0.0f, MaxValue);

                if (m_Value != value)
                {
                    m_Value = value;
                    ValueChanged.Invoke(m_Value);
                    PointValueChanged.Invoke(m_Value, m_MaxValue);
                }
            }
        }

        public readonly UnityEvent<float, float> PointValueChanged = new UnityEvent<float, float>();

        public void Regen(float value, float deltaTime)
        {
            Value += value * deltaTime;
        }

        public override string GetDescription() => "P";
        public override string GetValueString() => Value + "/" + MaxValue;
        public override abstract EStatType GetStatType();
    }
}