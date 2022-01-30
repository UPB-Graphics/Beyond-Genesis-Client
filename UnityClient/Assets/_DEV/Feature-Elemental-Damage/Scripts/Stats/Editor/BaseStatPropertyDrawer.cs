using UnityEngine;
using UnityEditor;

namespace ElementalDamage.StatManagement
{    
    [CustomPropertyDrawer(typeof(Regen<Health>))]
    [CustomPropertyDrawer(typeof(Regen<Mana>))]
    public class RegenPropertyDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var valueRect = new Rect(position.x, position.y, position.width / 4 * 3, position.height);
            var toggleRect = new Rect(position.x + position.width / 5 * 4 , position.y, position.width / 4, position.height);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("m_Value"), GUIContent.none);
            EditorGUI.PropertyField(toggleRect, property.FindPropertyRelative("IsActive"), GUIContent.none);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(Health))]
    [CustomPropertyDrawer(typeof(Mana))]
    public class PointStatPropertyDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var valueRect = new Rect(position.x, position.y, position.width / 2, position.height);
            var maxValueRect = new Rect(position.x + position.width / 2, position.y, position.width / 2, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("m_Value"), GUIContent.none);
            EditorGUI.PropertyField(maxValueRect, property.FindPropertyRelative("m_MaxValue"), GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(Resistance<Physical>))]
    [CustomPropertyDrawer(typeof(Resistance<Fire>))]
    [CustomPropertyDrawer(typeof(Resistance<Ice>))]
    [CustomPropertyDrawer(typeof(Resistance<Earth>))]
    [CustomPropertyDrawer(typeof(Resistance<Lightning>))]
    [CustomPropertyDrawer(typeof(Resistance<Nature>))]
    public class ResistancePropertyDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            BaseResistance resistance = fieldInfo.GetValue(property.serializedObject.targetObject) as BaseResistance;
            
            var valueRect = new Rect(position.x, position.y, position.width / 4 * 3, position.height);
            var percentRect = new Rect(position.x + position.width / 5 * 4, position.y, position.width / 5, position.height);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("m_Value"), GUIContent.none);
            EditorGUI.LabelField(percentRect, "", (resistance.DamageReduction * 100).ToString("F1") + "%");

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}