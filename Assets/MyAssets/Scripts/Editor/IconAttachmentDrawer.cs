using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(IconList))]
class IconListDrawer : PropertyDrawer
{
    int _selectedIndex;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();

        //redraw the enum list
        EditorGUI.indentLevel = 0;
        var enumValues = property.enumNames;
        _selectedIndex = EditorGUI.Popup(position, label.text, _selectedIndex, enumValues);
        property.enumValueIndex = _selectedIndex;
    }
}

[CustomPropertyDrawer(typeof(Texture2D))]
class IconTextureDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var content = EditorGUI.PrefixLabel(position, GUIContent.none);
        var iconAttachment = (IconAttachment)property.serializedObject.targetObject;
        // content.x = content.width + 100;

        EditorGUI.indentLevel = 0;
        var texture = IconDictionary.Instance.GetIconByID(iconAttachment.iconID);
        if (texture)
        {
            content.yMin = 50;
            content.width = 100;
            content.height = 100;
            EditorGUI.DrawPreviewTexture(content, IconDictionary.Instance.GetIconByID(iconAttachment.iconID));
        }
        else
        {
            content.height = 20;
            EditorGUI.ObjectField(content, property);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 120;
    }
}