using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoulType", menuName = "Scriptable Objects/SoulType")]
public class SoulType : ScriptableObject
{
    public List<string> Memories = new();
    public List<Mitzvah> Mitzvahs = new();
    public List<Sin> Sins = new();

}