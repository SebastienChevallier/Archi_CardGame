using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : AEffect
{
    public override void Use(object[] argV)
    {
        AEntity origin = (AEntity)argV[1];
        AEntity target = (AEntity)argV[2];

        /*foreach (var item in argV)
        {
            Debug.Log(item.GetType());
        }*/

        target.DrawCard(argV);
    }
}
