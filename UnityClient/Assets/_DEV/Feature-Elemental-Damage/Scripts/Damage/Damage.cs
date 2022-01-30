using UnityEngine;

namespace ElementalDamage
{
    [System.Serializable]
    public abstract class BaseDamage
    {
        [SerializeField] private float m_Value = 10;
        public float Value {
            get => m_Value;
            set => m_Value = value;
        }

        public BaseDamage() { }
        public BaseDamage(float value)
        {
            Value = value;
        }

        public abstract EElementalType GetElementalType();
        public abstract Element GetElement();
    }

    [System.Serializable]
    public class Damage<T> : BaseDamage where T : Element, new()
    {
        private readonly T m_Element = new T();
        
        public Damage() : base() { }
        public Damage(float value) : base(value) { }

        public override EElementalType GetElementalType()
        {
            return m_Element.GetElementalType();
        }

        public override Element GetElement() => m_Element;
    }
}