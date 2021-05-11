#region Description

// ----------------------------------------------------------------------------
// Came from
// https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/PropertyDrawer/PropertyAttribute.cs
//
// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License
// ----------------------------------------------------------------------------

#endregion

using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
public class HeaderAttribute : PropertyAttribute
{
    public readonly string header;

    public readonly string colorString;

    public readonly Color color;

    public readonly float textHeightIncrease;

    /// <summary>
    /// Creates a header with a line separator with the color. With a Text Height Increase of 1.
    /// </summary>
    /// <param name="header">The header to display.</param>
    /// <param name="colorString">The color can be specified in the traditional HTML format #rrggbbaa.
    /// Can use a name for a list of names "https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html"</param>
    public HeaderAttribute(string header, string colorString) : this(header, 1.5f, colorString) { }

    /// <summary>
    /// Creates a header with a line separator with the color and text height increase.
    /// Defaults to a height increase of 1.5.
    /// Defaults to lightblue if no color is given.
    /// </summary>
    /// <param name="header">The header to display.</param>
    /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
    /// <param name="colorString">The color can be specified in the traditional HTML format #rrggbbaa.
    /// Can use a name for a list of names "https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html"</param>
    public HeaderAttribute(string header, float textHeightIncrease = 1.5f, string colorString = "lightblue")
    {
        this.header = header;
        this.colorString = colorString;

        this.textHeightIncrease = Mathf.Max(1f, textHeightIncrease);

        if (string.IsNullOrEmpty(header))
            this.textHeightIncrease = 1f;

        if (ColorUtility.TryParseHtmlString(colorString, out color)) return;

        color = new Color(173, 216, 230);
        this.colorString = "lightblue";
    }
}
