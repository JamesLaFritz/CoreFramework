using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomPropertyDrawer(typeof(InputAxisAttribute))]
public class InputAxisPropertyDrawer : PropertyDrawer
{
    #region Overrides of PropertyDrawer

    /// <inheritdoc />
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property == null) return;

        if (property.propertyType != SerializedPropertyType.String)
        {
            Debug.LogError($"{nameof(InputAxisAttribute)} supports only string fields");
            return;
        }

        Object inputManagerAsset = AssetDatabase.LoadAssetAtPath("ProjectSettings/InputManager.asset", typeof(object));
        SerializedObject inputManager = new SerializedObject(inputManagerAsset);

        SerializedProperty axesProperty = inputManager.FindProperty("m_Axes");
        if (axesProperty == null || axesProperty.arraySize == 0)
        {
            Debug.LogError("No Axes Defined");
            return;
        }

        HashSet<string> axesSet = new HashSet<string> {"(None)"};

        for (int i = 0; i < axesProperty.arraySize; i++)
        {
            axesSet.Add(axesProperty.GetArrayElementAtIndex(i)?.FindPropertyRelative("m_Name")?.stringValue);
        }

        string[] axes = axesSet.ToArray();

        using (new EditorGUI.PropertyScope(position, label, property))
        {
            using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
            {
                string propertyString = property.stringValue;
                int index = 0;
                // check if there is an entry that matches the entry and get the index
                // we skip index 0 as that is a special custom case
                for (int i = 1; i < axes.Length; i++)
                {
                    if (axes[i] == null) continue;
                    if (!axes[i].Equals(propertyString, System.StringComparison.Ordinal)) continue;
                    index = i;
                    break;
                }

                // Draw the popup box with the current selected index
                int newIndex = EditorGUI.Popup(position, label?.text, index, axes);

                // Adjust the actual string value of the property based on the selection
                string newValue = newIndex > 0 ? axes[newIndex] : string.Empty;

                if (property.stringValue?.Equals(newValue, System.StringComparison.Ordinal) == false)
                {
                    property.stringValue = newValue;
                }

                if (changeCheck.changed)
                {
                    property.serializedObject?.ApplyModifiedProperties();
                }
            }
        }
    }

    #endregion
}
