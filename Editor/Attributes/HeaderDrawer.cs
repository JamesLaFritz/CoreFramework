#region Description

// ----------------------------------------------------------------------------
// Came from
// https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/ScriptAttributeGUI/Implementations/DecoratorDrawers.cs
//
// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License
// ----------------------------------------------------------------------------

#endregion

using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(HeaderAttribute))]
public class HeaderDrawer : DecoratorDrawer
{
    #region Overrides of DecoratorDrawer

    /// <inheritdoc />
    public override void OnGUI(Rect position)
    {
        if (!(attribute is HeaderAttribute headerAttribute)) return;

        position = EditorGUI.IndentedRect(position);
        position.yMin += EditorGUIUtility.singleLineHeight * (headerAttribute.textHeightIncrease - 0.5f);

        if (string.IsNullOrEmpty(headerAttribute.header))
        {
            position.height = headerAttribute.textHeightIncrease;
            EditorGUI.DrawRect(position, headerAttribute.color);
            return;
        }

        GUIStyle style = new GUIStyle(EditorStyles.label) {richText = true};
        GUIContent label = new GUIContent(
            $"<color={headerAttribute.colorString}><size={style.fontSize + headerAttribute.textHeightIncrease}><b>{headerAttribute.header}</b></size></color>");

        Vector2 textSize = style.CalcSize(label);
        float separatorWidth = (position.width - textSize.x) / 2.0f;

        Rect prefixRect = new Rect(position.xMin - 5f, position.yMin + 3f, separatorWidth, headerAttribute.textHeightIncrease);
        Rect labelRect = new Rect(position.xMin + separatorWidth, position.yMin - 3f, textSize.x, position.height);
        Rect postRect = new Rect(position.xMin + separatorWidth + 3f + textSize.x, position.yMin + 5f, separatorWidth, headerAttribute.textHeightIncrease);
        EditorGUI.DrawRect(prefixRect, headerAttribute.color);
        EditorGUI.LabelField(labelRect, label, style);
        EditorGUI.DrawRect(postRect, headerAttribute.color);
    }

    /// <inheritdoc />
    public override float GetHeight()
    {
        HeaderAttribute headerAttribute = attribute as HeaderAttribute;
        return EditorGUIUtility.singleLineHeight * (headerAttribute?.textHeightIncrease + 0.5f ?? 0);
    }

    #endregion
}
