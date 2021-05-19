using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(IconAttachment))]
class IconAttachmentInspector : Editor
{
    IconAttachment _iconAttachment;
    SerializedProperty _iconEnum, _iconTexture;

    void OnEnable()
    {
        _iconAttachment = (IconAttachment)target;
        _iconEnum = serializedObject.FindProperty(IconAttachment.IconIDFieldName);
        _iconTexture = serializedObject.FindProperty(IconAttachment.IconTextureFieldName);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}




