using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoulType", menuName = "Scriptable Objects/SoulType")]
public class SoulType : ScriptableObject
{
    public string name;
    public List<string> Memories = new();
    public Mitzvah Mitzvahs;
    public Sin Sins;
    public Sprite Picture;

}