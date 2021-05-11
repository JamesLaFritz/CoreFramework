using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TagAttribute))]
public class TagAttributePropertyDrawer : PropertyDrawer
{
    #region Overrides of PropertyDrawer

    /// <inheritdoc />
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property == null) return;

        if (property.propertyType != SerializedPropertyType.String)
        {
            Debug.LogError($"{nameof(TagAttribute)} supports only string fields");
            return;
        }

        using (new EditorGUI.PropertyScope(position, label, property))
        {
            using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
            {
                property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
                if (changeCheck.changed)
                {
                    property.serializedObject?.ApplyModifiedProperties();
                }
            }
        }
    }

    #endregion
}
