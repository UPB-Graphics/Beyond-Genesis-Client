using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ElementalDamage
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField] private Text m_Text;
        [SerializeField] private float m_VisibleDuration = 1.0f;
        private float m_VisibleTimer = 0.0f;
        private Vector3 m_Direction;
        
        public float DamageValue {
            set => m_Text.text = value.ToString("F0");
        }

        public string TextValue {
            set => m_Text.text = value;
        }

        public Color DamageColor {
            set => m_Text.color = value;
        }

        public readonly UnityEvent<bool, bool, DamagePopup> ActiveChanged = new UnityEvent<bool, bool, DamagePopup>();
        private bool m_IsActive;
        public bool IsActive {
            get => m_IsActive;
            set {
                gameObject.SetActive(value);
                ActiveChanged.Invoke(m_IsActive, value, this);
                m_IsActive = value;
            }
        }

        private void OnValidate()
        {
            if (m_Text == null)
                m_Text = GetComponentInChildren<Text>();
        }

        private void Update()
        {
            if (IsActive)
            {
                transform.localPosition += Time.deltaTime * m_Direction;
                m_Direction = Vector3.RotateTowards(m_Direction, Vector3.down, Mathf.PI / 4 * Time.deltaTime, 0);
            }

            if (m_VisibleTimer >= m_VisibleDuration)
            {
                IsActive = false;
            }
            else
            {
                m_VisibleTimer += Time.deltaTime;
            }

        }

        public void Setup(Vector3 position, Vector2 initialDirection, float value, Color color)
        {
            transform.position = position;
            m_Direction = initialDirection;
            DamageValue = value;
            DamageColor = color;
            m_VisibleTimer = 0.0f;
            IsActive = true;
        }

        public void Setup(Vector3 position, Vector2 initialDirection, string value, Color color)
        {
            transform.position = position;
            m_Direction = initialDirection;
            TextValue = value;
            DamageColor = color;
            m_VisibleTimer = 0.0f;
            IsActive = true;
        }
    }
}