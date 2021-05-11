using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneAttribute))]
public class SceneAttributePropertyDrawer : PropertyDrawer
{
    #region Overrides of PropertyDrawer

    /// <inheritdoc />
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property == null) return;

        string[] scenes = GetScenes();

        bool anySceneInBuildSettings = scenes?.Length > 0;
        if (!anySceneInBuildSettings)
        {
            Debug.LogError("No scenes in the build settings, Please ensure that you add your scenes to File->Build Settings->");
            return;
        }

        string[] sceneOptions = GetSceneOptions(scenes);

        using (new EditorGUI.PropertyScope(position, label, property))
        {
            using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
            {
                switch (property.propertyType)
                {
                    case SerializedPropertyType.String:
                        DrawPropertyForString(position, property, label, scenes, sceneOptions);
                        break;
                    case SerializedPropertyType.Integer:
                        DrawPropertyForInt(position, property, label, sceneOptions);
                        break;
                    default:
                        Debug.LogError(
                            $"{nameof(SceneAttribute)} supports only int or string fields! {property.propertyType}");
                        break;
                }

                if (changeCheck.changed)
                {
                    property.serializedObject?.ApplyModifiedProperties();
                }
            }
        }
    }

    #endregion

    private static string[] GetScenes()
    {
        return (from scene in EditorBuildSettings.scenes
                where scene.enabled
                select scene.path).ToArray();
    }

    private static string[] GetSceneOptions(string[] scenes)
    {
        return (from scene in scenes
                select Regex.Match(scene ?? string.Empty,
                                   @".+\/(.+).unity").Groups[1].Value).ToArray();
    }

    private static void DrawPropertyForString(Rect rect, SerializedProperty property, GUIContent label, string[] scenes, string[] sceneOptions)
    {
        if (property == null) return;
        if (scenes == null) return;

        int index = Mathf.Clamp(Array.IndexOf(scenes, property.stringValue), 0, scenes.Length - 1);
        int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, sceneOptions);
        string newScene = scenes[newIndex];

        if (property.stringValue?.Equals(newScene, StringComparison.Ordinal) == false)
        {
            property.stringValue = scenes[newIndex];
        }
    }

    private static void DrawPropertyForInt(Rect rect, SerializedProperty property, GUIContent label, string[] sceneOptions)
    {
        if (property == null) return;

        int index = property.intValue;
        int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, sceneOptions);

        if (property.intValue != newIndex)
        {
            property.intValue = newIndex;
        }
    }
}
