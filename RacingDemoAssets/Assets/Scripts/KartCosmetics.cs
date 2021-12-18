using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class KartCosmetics : MonoBehaviour
{
    public Texture albedo;
    public Renderer rend;

    private MaterialPropertyBlock _propBlock;

    private void OnEnable()
    {
        _propBlock = new MaterialPropertyBlock();
        
    }

    private void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        rend.GetPropertyBlock(_propBlock);
        _propBlock.SetTexture("_MainTex", albedo);
        rend.SetPropertyBlock(_propBlock);
    }

    private void OnValidate()
    {
        if (rend != null && _propBlock != null)
        {
            SetColor();
        }
    }
}
