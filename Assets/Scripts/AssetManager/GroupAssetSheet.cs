using System;
using UnityEngine;


[CreateAssetMenu(fileName = "GroupAssetSheet", menuName = "AssetManager/GroupAssetSheet", order = 0)]
public class GroupAssetSheet : ScriptableObject
{
    [SerializeField] private Groups group = Groups.Null;
    [SerializeField] private Sprite personSprite = null;

    public Groups Group => group;
    public Sprite PersonSprite => personSprite;
}
