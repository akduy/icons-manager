using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IconDictionary))]
class IconDictionaryEditor : Editor
{
    enum DisplayType
    {
        DisplayAutomaticFields, DisplayAsCustomizableGUIFields,
    }

    DisplayType _typeOfDisplay;
    IconDictionary _t;
    SerializedObject _getTarget;
    SerializedProperty _theList;
    int _sizeOfList;

    void OnEnable()
    {
        _t = (IconDictionary)target;
        _getTarget = new SerializedObject(_t);
        _theList = _getTarget.FindProperty("_list");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        // _theList.ClearArray();
        // _getTarget.Update();
    }
}