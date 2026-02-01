using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


struct Option
{
    public Option(Groups from, Groups to)
    {
        this.from = from;
        this.to = to;
    }

    public Groups from;
    public Groups to;
}
public class Spawner : MonoBehaviour
{
    [SerializeField] private AgitatorSpawner spawner;
    [SerializeField] private float spawnTime;

    private List<Option> availableAgitators;
    private List<Option> takenAgitators;
    
    Coroutine spawnCoroutine;
    
    
    private void Awake()
    {
        if(!spawner)
        {
            Debug.LogError("ERROR: SPAWNER NOT SET");
            gameObject.SetActive(false);
            return;
        }
        
        availableAgitators = new List<Option>();
        takenAgitators = new List<Option>();
        
        //Add the different agitator possibilities
        availableAgitators.Add(new Option(Groups.Skunks,Groups.Alligators));
        availableAgitators.Add(new Option(Groups.Skunks,Groups.Bees));
        
        availableAgitators.Add(new Option(Groups.Alligators,Groups.Skunks));
        availableAgitators.Add(new Option(Groups.Alligators,Groups.Sharks));
        
        availableAgitators.Add(new Option(Groups.Sharks,Groups.Alligators));
        availableAgitators.Add(new Option(Groups.Sharks,Groups.Bees));
        
        availableAgitators.Add(new Option(Groups.Bees,Groups.Sharks));
        availableAgitators.Add(new Option(Groups.Bees,Groups.Skunks));
    }

    private void OnEnable()
    {
        spawnCoroutine = StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnCoroutine);
    }

    public void ReturnOptions(Groups from, Groups to)
    {
        Option option =  new Option(from, to);
        if (takenAgitators.Contains(option))
        {
            takenAgitators.Remove(option);
            availableAgitators.Add(option);
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnRandom();
        }
    }

    private void SpawnRandom()
    {
        int randomChoice = Random.Range(0,availableAgitators.Count);
        Option choice = availableAgitators[randomChoice];
        
        takenAgitators.Add(choice);
        availableAgitators.Remove(choice);

        spawner.CreateAgitator(choice.from, choice.to);
    }
}
