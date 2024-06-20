using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEffect : ScriptableObject
{
    public string name;
    public string description;
    public int cost;
    public abstract void Use(object[] argV);
    
}
