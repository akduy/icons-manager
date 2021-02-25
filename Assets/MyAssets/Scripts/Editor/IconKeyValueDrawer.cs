using UnityEngine;
using UnityEditor;
using static IconDictionary;

[CustomPropertyDrawer(typeof(IconKeyValue))]
class IconKeyValueDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect contentPosition = EditorGUI.PrefixLabel(position, GUIContent.none);

        Rect iconRect = contentPosition;
        iconRect.width = 50;
        iconRect.height = 50;
        EditorGUI.indentLevel = 0;
        EditorGUI.ObjectField(iconRect, property.FindPropertyRelative("icon"), typeof(Texture2D), GUIContent.none);
        // EditorGUI.DrawPreviewTexture(iconRect, (Texture2D)property.FindPropertyRelative("icon").serializedObject.targetObject);

        Rect idRect = contentPosition;
        // idRect.width = contentPosition.width - iconRect.width - 20;
        // idRect.width = 250;
        idRect.height = 20f;
        idRect.x = iconRect.x + 70;

        // EditorGUI.PropertyField(idRect, property.FindPropertyRelative("ID"), GUIContent.none);
        // EditorGUI.TextField(idRect, label, property.FindPropertyRelative("ID").stringValue);
        EditorGUI.SelectableLabel(idRect, label.text);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 60f;
    }
}