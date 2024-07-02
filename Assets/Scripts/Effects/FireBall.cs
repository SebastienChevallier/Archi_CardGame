using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
[CreateAssetMenu(fileName = "CardData", menuName = "Card/FireBall", order = 1)]
public class FireBall : AEffect
{
    public int damageValue;
    public override void Use(object[] argV)
    {
        AEntity origin = (AEntity)argV[1];
        AEntity target = (AEntity)argV[2];
/*
        foreach (var item in argV)
        {
            Debug.Log(item.GetType());
        }*/

        target.TakeDamage(damageValue, argV);
    }
}
