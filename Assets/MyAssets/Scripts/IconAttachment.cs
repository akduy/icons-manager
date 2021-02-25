using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconAttachment : MonoBehaviour
{
    public class Attachment
    {
    }
    public IconList iconID;

    public Texture2D iconTexture;
    public const string IconIDFieldName = "iconID";
    public const string IconTextureFieldName = "iconTexture";

    void OnValidate()
    {
        // iconTexture = IconDictionary.Instance.GetIconByID(iconID);
    }
}
