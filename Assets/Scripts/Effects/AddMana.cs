using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CardData", menuName = "Card/AddMana", order = 1)]
public class AddMana : AEffect
{
    public int manaValue;
    public override void Use(object[] argV)
    {
        AEntity origin = (AEntity)argV[1];
        AEntity target = (AEntity)argV[2];
        /*
                foreach (var item in argV)
                {
                    Debug.Log(item.GetType());
                }*/

        origin.UpdateManaValue(-manaValue);
    }
}
