using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test1))]
public class Test2Inspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // DrawDefaultInspector();
    }
}