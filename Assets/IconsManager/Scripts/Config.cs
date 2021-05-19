using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Config : ScriptableObject
{
    [SerializeField] string _dictionaryPath, _iconFolderPath;
    public static string IconDictionaryAssetPath { get; private set; }
    public static string IconFolderPath { get; private set; }
    public static string IconEnumPath { get; private set; }
    const string IconDictionaryAssetName = "IconDictionaryAsset.asset";
    const string key = "IconFolderPath";

#if UNITY_EDITOR
    void OnEnable()
    {
        IconDictionaryAssetPath = $"{GetCurrentFolderPath()}/IconDictionaryAsset.asset";
        IconFolderPath = PlayerPrefs.GetString(key, string.Empty);
        IconEnumPath = $"{GetCurrentFolderPath()}/Scripts/IconList.cs";

        _dictionaryPath = IconDictionaryAssetPath;
        _iconFolderPath = IconFolderPath;
    }

    [MenuItem("MyAssets/Common/Icons Manager/Config Path")]
    public static void ConfigPath()
    {
        var rawPath = EditorUtility.OpenFolderPanel("Select Folder", Application.dataPath, "");

        var index = rawPath.IndexOf("Assets");
        IconFolderPath = rawPath.Substring(index);
        // Debug.Log($"IconFolderPath = {IconFolderPath}");
        PlayerPrefs.SetString(key, IconFolderPath);
        PlayerPrefs.Save();
    }
    void OnValidate()
    {
        _dictionaryPath = IconDictionaryAssetPath;
    }

    [ContextMenu("Test Log")]
    void TestLog()
    {
        Debug.Log(IconDictionaryAssetPath);
    }

    static string GetCurrentFolderPath()
    {
        var filePath = AssetDatabase.GetAssetPath(Resources.FindObjectsOfTypeAll<Config>().FirstOrDefault());
        var splitter = '/';
        var splitString = filePath.Split(splitter);
        var folderPath = filePath.Replace(splitString[splitString.Length - 1], string.Empty);
        return folderPath;
    }
#endif
}