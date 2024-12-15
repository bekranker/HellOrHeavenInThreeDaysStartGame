using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoulType", menuName = "Scriptable Objects/SoulType")]
public class SoulType : ScriptableObject
{
    public string name;
    public string JobTitle;
    public string Sex;
    public List<string> Memories = new();
    public Sprite Picture;
    public string JugmentOne;
    public string JugmentTwo;

}