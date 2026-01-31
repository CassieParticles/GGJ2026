
using System.Collections;
using UnityEngine;



[RequireComponent(typeof(SpriteRenderer))]
public class AgitatorBehaviour: MonoBehaviour
{
    private Groups source;
    private Groups destination;

    private GroupBehaviour sourceGO;
    private GroupBehaviour destinationGO;
    
    private bool atDestination;
    
    private bool SetAssets(GroupAssetSheet assetSheet)
    {
        if (!assetSheet)
        {
            Debug.LogError("ERROR: NO ASSET SHEET FOUND");
            return false;
        }

        GetComponent<SpriteRenderer>().sprite = assetSheet.PersonSprite;
        
        return true;
    }
    
    public void Initialize(Groups from, Groups to, GroupAssetSheet assetSheet)
    {
        SetAssets(assetSheet);
        
        this.source = from;
        this.destination = to;
        
        sourceGO = GroupBehaviour.GetGroup(from);
        destinationGO = GroupBehaviour.GetGroup(to);

        atDestination = false;
        StartCoroutine(TravelTo());
    }

    private IEnumerator TravelTo()
    {
        //Wait for travel to be done
        transform.position = sourceGO.transform.position;
        
        yield return new WaitForSeconds(3.0f);
        
        //Teleport to destination
        transform.position = destinationGO.transform.position;
        
        //Add to the "to" function and wait to be picked up
        atDestination = true;
        destinationGO.AddAgitator(this);
    }

    //TODO: When player class added, this takes in player
    //Called by player when player picks up an agitator
    public void PlayerPickup()
    {
        //Doesn't need to be removed, player will handle that
        
        //TODO: follows player when player exists
    }

    //Called when player reaches agitators home destination
    public void ReturnToDestination()
    {
        Destroy(gameObject);
    }
}
