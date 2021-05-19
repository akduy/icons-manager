using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(IconEnum))]
class IconListDrawer : PropertyDrawer
{
    int _selectedIndex;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // //redraw the enum list
        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.indentLevel = 0;
        var targetEnum = property.intValue;
        property.intValue = EditorGUI.Popup(position, label.text, property.intValue, property.enumNames);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(Sprite))]
class IconTextureDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var content = EditorGUI.PrefixLabel(position, GUIContent.none);
        var iconAttachment = (IconAttachment)property.serializedObject.targetObject;
        // content.x = content.width + 100;

        EditorGUI.indentLevel = 0;
        Texture2D texture = null;
        var spr = IconsManager.Instance.Dictionary.GetIconByID(iconAttachment.ID);

        if (IconsManager.Instance.Dictionary != null && spr != null)
            texture = spr.texture;

        if (texture)
        {
            content.yMin = 50;
            content.width = 80;
            content.height = 80;
            // EditorGUI.DrawPreviewTexture(content, IconDictionary.Instance.GetIconByID(iconAttachment.ID).texture);
            EditorGUI.ObjectField(content, texture, typeof(Sprite), false);
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