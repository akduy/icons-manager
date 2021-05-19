using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class IconDictionary : ScriptableObject
{
    [Serializable]
    public class IconKeyValue
    {
        public string ID;
        public Sprite icon;

        public IconKeyValue(Sprite newIcon)
        {
            icon = newIcon;
            ID = IDGenerator.Get(8);

            Debug.Log($"list add {icon} - {ID}");
        }
    }

//     public static IconDictionary Instance
//     {
//         get
//         {
//             if (_instance == null)
//             {
// #if UNITY_EDITOR
//                 Debug.Log(Config.IconDictionaryAssetPath);
//                 //                 _instance = (IconDictionary)AssetDatabase.LoadAssetAtPath(Config.IconDictionaryAssetPath, typeof(IconDictionary));
//                 _instance = Resources.FindObjectsOfTypeAll<IconDictionary>().FirstOrDefault();
// #endif
//             }
//             return _instance;
//         }
//     }

    public List<IconKeyValue> IconList { get => _list; }

    static IconDictionary _instance;
    static bool _lock;

    [SerializeField] List<IconKeyValue> _list;

#if UNITY_EDITOR
    public void RegisterIcon(Sprite icon)
    {
        if (_list == null)
            _list = new List<IconKeyValue>();

        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i].icon == icon)
                return;
        }

        _list.Add(new IconKeyValue(icon));

        // EditorUtility.SetDirty(IconDictionary.Instance);
        AssetDatabase.SaveAssets();
    }
#endif

    public Sprite GetIconByID(IconEnum requestID)
    {
        if (_list == null)
            return null;
        var result = _list.FirstOrDefault(item => item.ID == requestID.ToString());
        return result != null ? result.icon : null;
    }

    [ContextMenu("Clean list")]
    void CleanList()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i].icon == null)
                _list.Remove(_list[i]);
        }
    }

    [ContextMenu("Clear list")]
    void ResetData()
    {
        _list.Clear();
    }

    [ContextMenu("Toggle Edit")]
    void ToggleEdit()
    {
        _lock = !_lock;
        hideFlags = _lock ? HideFlags.NotEditable : HideFlags.None;
    }

    void OnValidate()
    {
        CleanList();
    }
}
