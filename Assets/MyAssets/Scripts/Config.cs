using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "HID/Config", order = 0)]
[ExecuteInEditMode]
public class Config : ScriptableObject
{
    const string IconDictionaryAssetName = "IconDictionaryAsset.asset";
    public static string IconDictionaryAssetPath;

    [MenuItem("HID/Config Path")]
    public static void ConfigPath()
    {
        var str = EditorUtility.OpenFolderPanel("Select Folder", Application.dataPath, "");

        var tr = str.IndexOf("Assets");
        IconDictionaryAssetPath = str.Substring(tr) + "/" + IconDictionaryAssetName;
        Debug.Log($"IconDictionaryPath = {IconDictionaryAssetPath}");
    }
}