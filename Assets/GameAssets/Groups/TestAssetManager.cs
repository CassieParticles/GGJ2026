using System;
using UnityEngine;



public class TestAssetManager : MonoBehaviour
{
    [SerializeField] private Groups group;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        GroupAssetSheet assetSheet = AssetManager.GetSheet(group);
        if (assetSheet != null)
        {
            spriteRenderer.sprite = assetSheet.PersonSprite;
        }
    }
}
