using System;
using UnityEngine;


[CreateAssetMenu(fileName = "GroupAssetSheet", menuName = "AssetManager/GroupAssetSheet", order = 0)]
public class GroupAssetSheet : ScriptableObject
{
    [SerializeField] private Groups group;
    [SerializeField] private Sprite personSprite;

    public Groups Group => group;
    public Sprite PersonSprite => personSprite;

    private void Awake()
    {
        throw new NotImplementedException();
    }

    private void OnValidate()
    {
        throw new NotImplementedException();
    }
}
