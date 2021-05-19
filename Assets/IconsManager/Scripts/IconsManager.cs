using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IconsManager : MonoBehaviour
{
    public static IconsManager Instance
    {
        get
        {
            if (_instance == null)
            {
#if UNITY_EDITOR
                var newObj = GameObject.FindObjectOfType<IconsManager>();
                if (newObj == null)
                    newObj = new GameObject("[Singleton]-IconsManager").AddComponent<IconsManager>();
                _instance = newObj.GetComponent<IconsManager>();
#endif
            }
            return _instance;
        }
    }

    static IconsManager _instance;

    public IconDictionary Dictionary
    {
        get
        {
#if UNITY_EDITOR

            if (_dictionary == null)
            {
                _dictionary = AssetDatabase.LoadAssetAtPath<IconDictionary>(Config.IconDictionaryAssetPath);
            }
#endif
            return _dictionary;
        }
    }

    [SerializeField] IconDictionary _dictionary;

}
