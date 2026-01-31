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
    [SerializeField] private GroupAssetSheet assetSheet;
    
    [SerializeField] private float angerBuildRate = 5;
    [SerializeField] private float angerPlayerDecayRate = 25;
    [SerializeField] private float angerAgitatorBuildRate = 10;
    [SerializeField] private float angerLoseCap = 100;
    private float anger;

    private bool playerPresent;

    private Queue<AgitatorBehaviour> agitators;
    
    private void Awake()
    {
        if (!SetAssets())
        {
            //Setting up assets was unsuccessful, exit
            this.enabled = false;
            return;
        }

        agitators =  new Queue<AgitatorBehaviour>();
        anger = 0;
        playerPresent = false;
    }

    private bool SetAssets()
    {
        //Asset sheet is null
        if (!assetSheet)
        {
            Debug.LogError("ERROR: GROUP NOT SET");
            return false;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = assetSheet.PersonSprite;

        return true;
    }

    //Tell the group the player has arrived
    public void PlayerArrive()
    {
        playerPresent = true;
    }

    //Tell the group the player has left
    public void PlayerLeave()
    {
        playerPresent = false;
    }

    //Add a new agitator to the group behaviour
    public void AddAgitator(AgitatorBehaviour agitator)
    {
        agitators.Enqueue(agitator);
    }

    //Remove the agitator from the group, and return it (returns null if no agitators present)
    public AgitatorBehaviour GetAgitator()
    {
        return agitators.Count > 0 ? agitators.Dequeue() : null;
    }

    private void FixedUpdate()
    {
        //Increase/decrease anger based on if player is present
        anger += (playerPresent ? -angerPlayerDecayRate : angerBuildRate) * Time.fixedDeltaTime;
        
        //Additional anger from agitators
        anger += agitators.Count * angerAgitatorBuildRate * Time.fixedDeltaTime;

        if (anger > angerLoseCap)
        {
            //TODO: Add losing functionality
        }
    }
}
