using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class IconsManagerEditor
{
    public const string IconDictionaryName = "IconDictionaryAsset";
    public static string IconDictionaryPath = $"Assets/MyAssets/SciptableAssets/{IconDictionaryName}.asset";

    [MenuItem("HID/Create Dictionary")]
    public static void CreateDictionary()
    {
        AssetDatabase.CreateAsset(IconDictionary.CreateInstance("IconDictionary"),
        IconDictionaryPath);
    }

    [MenuItem("HID/Register Icon")]
    public static void CreateIcons()
    {
        
        var selected = Selection.objects;

        for (int i = 0; i < selected.Length; i++)
        {
            try
            {
                var icon = (Texture2D)selected[i];
                IconDictionary.Instance.RegisterIcon(icon);
            }
            catch
            {
                continue;
            }
        }

        EditorGUIUtility.PingObject(IconDictionary.Instance);
    }
}
