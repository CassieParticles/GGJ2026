using System;
using UnityEngine;



public class TestAssetManager : MonoBehaviour
{
    [SerializeField] private GroupAssetSheet group;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (group)
        {
            spriteRenderer.sprite = group.PersonSprite;
        }
    }
}
