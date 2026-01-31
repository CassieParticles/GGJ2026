using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

[Serializable]
public enum Groups
{
    Null,
    Skunks,
    Bees,
    Sharks,
    Alligators
}

[RequireComponent(typeof(SpriteRenderer))]
public class GroupBehaviour : MonoBehaviour
{
    [SerializeField] private Groups group;
    
    [SerializeField] private float angerBuildRate = 5;
    [SerializeField] private float angerPlayerDecayRate = 25;
    [SerializeField] private float angerAgitatorBuildRate = 10;

    private Queue<AgitatorBehaviour> agitators;
    
    private void Awake()
    {
        //Get the asset sheet
        GroupAssetSheet assetSheet = AssetManager.GetSheet(group);
        
        //Ensure the asset sheet was retrieved successfully
        if (!assetSheet)
        {
            //Log the error so bug can be tracked easier
            Debug.LogError("ERROR: GROUP NOT SET");
            //Do not run behaviour with missing assets (disable script and immediately return)
            this.enabled = false;
            return;
        }
        //Get the sprite sheet and set its sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = assetSheet.PersonSprite;
        
        agitators =  new Queue<AgitatorBehaviour>();
    }

    private void FixedUpdate()
    {
        
    }
}
