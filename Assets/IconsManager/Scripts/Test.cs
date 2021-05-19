using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    [ContextMenu("Test Log")]
    void TestLog()
    {
        Debug.Log(IconsManager.Instance.Dictionary);
    }
}
