
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AngerBar: MonoBehaviour
{
    GroupBehaviour group;
    public VisualElement gui;
    public ProgressBar angerbar1;
    public ProgressBar angerbar2;
    public ProgressBar angerbar3;
    public ProgressBar angerbar4;
    public float angerval1;
    public float angerval2;
    public float angerval3;
    public float angerval4;
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
        gui = GetComponent<UIDocument>().rootVisualElement;
        Debug.Log("I got the GUI OBJ");
        angerbar1 = gui.Q<ProgressBar>("BeeBar");
        angerbar2 = gui.Q<ProgressBar>("SharkBar");
        angerbar3 = gui.Q<ProgressBar>("CrocBar");
        angerbar4 = gui.Q<ProgressBar>("SkunkBar");
        Debug.Log("BarsFound");

    }

    private void Start()
    {
        //Set initial values for GUI bar
        angerval1 = 0;
        angerval2 = 0;
        angerval3 = 0;
        angerval4 = 0;

    }

    private void FixedUpdate()
    {
        //TODO: Set GUI bar to value
        // if bar hits zero Lose();
    }
}
