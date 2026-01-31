using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "AgitatorSpawner", menuName = "Agitator/AgitatorSpawner", order = 0)]
public class AgitatorSpawner : ScriptableObject
{
    [SerializeField] private AgitatorBehaviour agitatorPrefab;
    
    [SerializeField] private GroupAssetSheet[]  groupAssetSheets;

    public AgitatorBehaviour CreateAgitator(Groups from, Groups to)
    {
        AgitatorBehaviour agitator = Instantiate(agitatorPrefab);

        //Set up agitator
        
        //Get asset sheet
        GroupAssetSheet assetSheet = null;
        foreach (GroupAssetSheet sheet in groupAssetSheets)
        {
            if (sheet.Group == from)
            {
                assetSheet = sheet;
                break;
            }
        }
        
        agitator.Initialize(from,to,assetSheet);
        
        return agitator;
    }
}
