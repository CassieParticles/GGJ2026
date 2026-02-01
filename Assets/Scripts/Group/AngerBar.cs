
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AngerBar: MonoBehaviour
{
    [SerializeField] private GroupBehaviour beeGroup;
    [SerializeField] private GroupBehaviour sharkGroup;
    [SerializeField] private GroupBehaviour crocGroup;
    [SerializeField] private GroupBehaviour skunkGroup;
    
    public VisualElement gui;
    public ProgressBar beeBar;
    public ProgressBar sharkBar;
    public ProgressBar crocBar;
    public ProgressBar skunkBar;
    public float angerval1;
    public float angerval2;
    public float angerval3;
    public float angerval4;
    private void Awake()
    {
        //TODO: Get GUI bar
        gui = GetComponent<UIDocument>().rootVisualElement;
        Debug.Log("I got the GUI OBJ");
        beeBar = gui.Q<ProgressBar>("BeeBar");
        sharkBar = gui.Q<ProgressBar>("SharkBar");
        crocBar = gui.Q<ProgressBar>("CrocBar");
        skunkBar = gui.Q<ProgressBar>("SkunkBar");
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
        angerval1 = beeGroup.Anger;
        angerval2 = sharkGroup.Anger;
        angerval3 = crocGroup.Anger;
        angerval4 = skunkGroup.Anger;

        beeBar.value = beeGroup.Anger;
        sharkBar.value = sharkGroup.Anger;
        crocBar.value = crocGroup.Anger;
        skunkBar.value = skunkGroup.Anger;


        // if bar hits zero Lose();
    }
    private void Lose()
    {
    
    
    }

}
