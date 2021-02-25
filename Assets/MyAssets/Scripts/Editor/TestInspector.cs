using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IconDictionary))]
class TestInspector : Editor
{
    Editor _editor;
    IconDictionary _script;

    void OnEnable()
    {
        // _editor = Editor.CreateEditor(IconDictionary.Instance);
        // if (_editor == null)
        //     Editor.CreateCachedEditor(IconDictionary.Instance, typeof(TestInspector), ref _editor);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}