
using System;
using UnityEngine;

public class AngerBar: MonoBehaviour
{
    GroupBehaviour group;
    private void Awake()
    {
        group = GetComponentInParent<GroupBehaviour>();
        if (!group)
        {
            Debug.LogError("ERROR: GROUP NOT LOCATED");
            gameObject.SetActive(false);
            return;
        }
        
        //TODO: Get GUI bar
    }

    private void Start()
    {
        //Set initial values for GUI bar
    }

    private void FixedUpdate()
    {
        //TODO: Set GUI bar to value
    }
}
