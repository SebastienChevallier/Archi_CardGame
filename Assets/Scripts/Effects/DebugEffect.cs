using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Card/DebugEffect", order = 1)]
public class DebugEffect : AEffect
{
    public override void Use(object[] argV)
    {
        foreach (object arg in argV) 
        {
            Debug.Log(arg);
        }
    }
}
