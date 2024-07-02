using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CardData", menuName = "Card/Heal", order = 1)]
public class BasicHeal : AEffect
{
    public int healValue;
    public override void Use(object[] argV)
    {
        AEntity origin = (AEntity)argV[1];
        AEntity target = (AEntity)argV[2];
        /*
                foreach (var item in argV)
                {
                    Debug.Log(item.GetType());
                }*/

        origin.TakeDamage(-healValue, argV);
    }
}
