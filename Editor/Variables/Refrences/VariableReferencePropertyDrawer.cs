#region Description

// 03-05-2021
// James LaFritz
// ----------------------------------------------------------------------------
// Based on
//
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

#endregion

using UnityEditor;
using UnityEngine;

public static class VariableReferencePropertyDrawer
{
    /// <summary>
    /// Options to display in the popup to select constant or variable.
    /// </summary>
    private static readonly string[] PopupOptions =
        {"Use Constant", "Use Variable"};

    /// <summary> Cached style to use to draw the popup button. </summary>
    private static GUIStyle _popupStyle;

    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (_popupStyle == null)
        {
            _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly
            };
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck();

        // Get properties
        SerializedProperty useConstant = property?.FindPropertyRelative("useConstant");
        SerializedProperty constantValue = property?.FindPropertyRelative("constantValue");
        SerializedProperty variable = property?.FindPropertyRelative("variable");

        // Calculate rect for configuration button
        Rect constantButtonRect = new Rect(position);
        Debug.Assert(_popupStyle.margin != null, "m_popupStyle.margin != null");
        constantButtonRect.yMin += _popupStyle.margin.top;
        constantButtonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
        position.xMin = constantButtonRect.xMax;

        // Store old indent level and set it to 0, the PrefixLabel takes care of it
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        int useConstantResults = EditorGUI.Popup(constantButtonRect, useConstant?.boolValue == true ? 0 : 1,
                                                 PopupOptions, _popupStyle);

        if (useConstant != null)
        {
            useConstant.boolValue = useConstantResults == 0;

            EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variable, GUIContent.none,
                                    useConstant.boolValue);
        }

        if (EditorGUI.EndChangeCheck())
            property?.serializedObject?.ApplyModifiedProperties();

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }

    public static float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float totalHeight = EditorGUI.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight;

        SerializedProperty useConstant = property?.FindPropertyRelative("useConstant");
        if (useConstant?.boolValue != true) return totalHeight;

        SerializedProperty constantValue = property.FindPropertyRelative("constantValue");
        totalHeight += constantValue.CountInProperty() * EditorGUIUtility.singleLineHeight;

        return totalHeight;
    }
}