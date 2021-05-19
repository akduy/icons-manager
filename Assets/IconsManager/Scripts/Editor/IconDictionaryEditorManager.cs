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

    [MenuItem("MyAssets/Common/Icons Manager/Create Dictionary")]
    public static void CreateDictionary()
    {
        AssetDatabase.CreateAsset(IconDictionary.CreateInstance("IconDictionary"),
            Config.IconDictionaryAssetPath);
        EditorGUIUtility.PingObject(IconsManager.Instance.Dictionary);
    }

    [MenuItem("Assets/Common/Icons Manager/Register Icons")]
    [MenuItem("MyAssets/Common/Icons Manager/Register Icons")]
    public static void CreateIcons()
    {
        // var selected = Selection.objects;
        // // Debug.Log(selected.Length);
        // for (int i = 0; i < selected.Length; i++)
        // {
        //     Debug.Log(selected[i]);
        //     try
        //     {
        //         var tex = (Texture2D)selected[i];
        //         IconsManager.Instance.Dictionary.RegisterIcon(tex);
        //     }
        //     catch
        //     {
        //         continue;
        //     }
        // }
        var path = Config.IconFolderPath + "/";
        var files = Directory.GetFiles(path);
        foreach (var pFile in files)
        {
            if (pFile.Contains(".meta"))
                continue;
            var pSprite = AssetDatabase.LoadAssetAtPath<Sprite>(pFile);
            Debug.Log($"file path: {pFile}, sprite: {pSprite}");
            // for (int i = 0; i < pSprite.Length; i++)
            // {
            //     if (pSprite[i] is Sprite)
            // }
            IconsManager.Instance.Dictionary.RegisterIcon(pSprite);
        }

        UpdateIconEnums(IconsManager.Instance.Dictionary.IconList);
        EditorGUIUtility.PingObject(IconsManager.Instance.Dictionary);
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
        var enumName = "IconEnum";
        var path = Config.IconEnumPath;
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
