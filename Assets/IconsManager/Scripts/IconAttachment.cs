using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IconAttachment : MonoBehaviour
{
    public IconEnum ID => _id;
    public Sprite IconTexture => _iconTexture;

    [SerializeField] IconEnum _id;
    [SerializeField] Sprite _iconTexture;

    public const string IconIDFieldName = "iconID";
    public const string IconTextureFieldName = "iconTexture";

    void OnValidate()
    {
        if (IconsManager.Instance.Dictionary != null)
            _iconTexture = IconsManager.Instance.Dictionary.GetIconByID(_id);
    }

    [ContextMenu("Random sprite")]
    void RandomSprite()
    {
        var values = Enum.GetValues(typeof(IconEnum));
        var pIndex = Random.Range(0, values.Length - 1);
        var pResult = (IconEnum)values.GetValue(pIndex);
        _id = pResult;
        _iconTexture = IconsManager.Instance.Dictionary.GetIconByID(_id);
    }
}
