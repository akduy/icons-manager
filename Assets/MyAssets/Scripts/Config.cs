using UnityEditor;
using UnityEngine;

public class Config : ScriptableObject
{
    [SerializeField] string _path;
    public static string IconDictionaryAssetPath;
    const string IconDictionaryAssetName = "IconDictionaryAsset.asset";
    const string key = "ConfigPathKey";

    void OnEnable()
    {
        IconDictionaryAssetPath = PlayerPrefs.GetString(key, "Path is Empty");
        _path = IconDictionaryAssetPath;
    }

    [MenuItem("HID/Config Path")]
    public static void ConfigPath()
    {
        var str = EditorUtility.OpenFolderPanel("Select Folder", Application.dataPath, "");

        var tr = str.IndexOf("Assets");
        IconDictionaryAssetPath = str.Substring(tr) + "/" + IconDictionaryAssetName;
        // Debug.Log($"IconDictionaryPath = {IconDictionaryAssetPath}");

        PlayerPrefs.SetString(key, IconDictionaryAssetPath);
        PlayerPrefs.Save();
    }

    void OnValidate()
    {
        _path = IconDictionaryAssetPath;
    }
}