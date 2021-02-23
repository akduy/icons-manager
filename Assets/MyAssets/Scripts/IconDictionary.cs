﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "IconDictionary", menuName = "IconDictionary", order = 0)]
public class IconDictionary : ScriptableObject
{
    [Serializable]
    public class IconKeyValue
    {
        public string ID;
        public Texture2D icon;

        public IconKeyValue(Texture2D newIcon)
        {
            icon = newIcon;
            ID = IDGenerator.Get(8);

            Debug.Log($"list add {icon} - {ID}");
        }
    }


    public static IconDictionary Instance
    {
        get
        {
            if (_instance == null)
            {
#if UNITY_EDITOR
                _instance = (IconDictionary)AssetDatabase.LoadAssetAtPath("Assets/MyAssets/ScriptableAssets/IconDictionaryAsset.asset", typeof(IconDictionary));
#else
                _instance = Resources.FindObjectsOfTypeAll<IconDictionary>().FirstOrDefault();
#endif
            }
            return _instance;
        }
    }
    static IconDictionary _instance;
    static bool _lock;

    [SerializeField] List<IconKeyValue> _list;

    public void RegisterIcon(Texture2D icon)
    {
        if (_list == null)
            _list = new List<IconKeyValue>();

        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i].icon == icon)
                return;
        }

        _list.Add(new IconKeyValue(icon));

        EditorUtility.SetDirty(IconDictionary.Instance);
        AssetDatabase.SaveAssets();
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
}