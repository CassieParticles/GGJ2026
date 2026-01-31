using UnityEngine;

[CreateAssetMenu(fileName = "AgitatorSpawner", menuName = "Agitator/AgitatorSpawner", order = 0)]
public class AgitatorSpawner : ScriptableObject
{
    [SerializeField] private AgitatorBehaviour agitatorPrefab;

    AgitatorBehaviour CreateAgitator(Groups from, Groups to)
    {
        AgitatorBehaviour agitator = Instantiate(agitatorPrefab);

        //Set up agitator
        
        
        return agitator;
    }
}
