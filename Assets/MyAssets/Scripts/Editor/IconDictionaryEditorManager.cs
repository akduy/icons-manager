using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static IconDictionary;
using System;
using System.IO;

public static class IconDictionaryEditorManager
{
    public const string IconDictionaryName = "IconDictionaryAsset";
    public static string IconDictionaryPath = $"Assets/MyAssets/SciptableAssets/{IconDictionaryName}.asset";

    [MenuItem("HID/Create Dictionary")]
    public static void CreateDictionary()
    {
        AssetDatabase.CreateAsset(IconDictionary.CreateInstance("IconDictionary"),
            Config.IconDictionaryAssetPath);
        EditorGUIUtility.PingObject(IconDictionary.Instance);
    }

    [MenuItem("Assets/HID/Register Icons")]
    [MenuItem("HID/Register Icons")]
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

        UpdateIconEnums(IconDictionary.Instance.IconList);
        EditorGUIUtility.PingObject(IconDictionary.Instance);
    }

    public static void UpdateIconEnums(List<IconKeyValue> iconList)
    {
        var idList = new List<string>();
        for (int i = 0; i < iconList.Count; i++)
        {
            idList.Add(iconList[i].ID);
        }
        WriteToFile(idList);
    }

    private static void WriteToFile(List<string> idList)
    {
        var enumName = "IconList";
        var path = "Assets/MyAssets/Scripts/IconEnum.cs";
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine("public enum " + enumName);
            sw.WriteLine("{");

            for (int i = 0; i < idList.Count; i++)
            {
                sw.WriteLine("\t" + idList[i] + ",");
            }
            sw.WriteLine("}");
        }

        AssetDatabase.Refresh();
    }

}
