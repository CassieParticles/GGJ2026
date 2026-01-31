using System;
using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
    [SerializeField] private AgitatorSpawner spawner;

    private void Start()
    {
        spawner.CreateAgitator(Groups.Alligators, Groups.Bees);
    }
}
