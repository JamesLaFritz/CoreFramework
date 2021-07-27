using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(InfoBoxAttribute))]
public class InfoBoxDecoratorDrawer : DecoratorDrawer
{
    #region Overrides of DecoratorDrawer

    /// <inheritdoc />
    public override void OnGUI(Rect position)
    {
        if (!(attribute is InfoBoxAttribute infoBoxAttribute)) return;

        Rect indentRect = EditorGUI.IndentedRect(position);
        float indentLength = indentRect.x - position.x;
        Rect infoBoxRect = new Rect(
            position.x + indentLength,
            position.y,
            position.width - indentLength,
            GetHeight());

        DrawInfoBox(infoBoxRect, infoBoxAttribute.text, infoBoxAttribute.infoBoxType);
    }

    /// <inheritdoc />
    public override float GetHeight()
    {
        InfoBoxAttribute infoBoxAttribute = (InfoBoxAttribute) attribute;
        float minHeight = EditorGUIUtility.singleLineHeight * 2.0f;
        float desiredHeight =
            GUI.skin.box.CalcHeight(new GUIContent(infoBoxAttribute.text), EditorGUIUtility.currentViewWidth);
        float height = Mathf.Max(minHeight, desiredHeight);

        return height;
    }

    #endregion

    private void DrawInfoBox(Rect position, string infoText, InfoBoxType infoBoxType)
    {
        MessageType messageType = infoBoxType switch
        {
            InfoBoxType.Info => MessageType.Info,
            InfoBoxType.Warning => MessageType.Warning,
            InfoBoxType.Error => MessageType.Error,
            _ => MessageType.None
        };

        EditorGUI.HelpBox(position, infoText, messageType);
    }
}
