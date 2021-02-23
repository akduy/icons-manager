using UnityEngine;
using UnityEditor;
using static IconDictionary;

[CustomPropertyDrawer(typeof(IconKeyValue))]
class IconKeyValueDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect contentPosition = EditorGUI.PrefixLabel(position, label);

        Rect iconRect = contentPosition;
        // iconRect.width *= 0.3f;
        iconRect.width = 50;
        iconRect.height = 50;
        EditorGUI.indentLevel = 0;
        EditorGUI.ObjectField(iconRect, property.FindPropertyRelative("icon"), typeof(Texture2D), GUIContent.none);
        // EditorGUI.DrawPreviewTexture(iconRect, (Texture2D)property.FindPropertyRelative("icon").serializedObject.targetObject);

        Rect idRect = contentPosition;
        // idRect.width *= 0.5f;
        idRect.width = contentPosition.width - iconRect.width - 20;
        idRect.height = 20f;
        idRect.x = iconRect.x + 70;

        EditorGUI.PropertyField(idRect, property.FindPropertyRelative("ID"), GUIContent.none);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 75f;
    }
}