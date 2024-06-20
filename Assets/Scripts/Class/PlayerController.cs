using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AEntity
{
    public GameObject handParent;
    

    public override void AddCardToHand(object[] argV)
    {
        if (!(bool)argV[1]) return;
        GameObject obj = Instantiate(prefabCard, handParent.transform);
        Card card = obj.GetComponent<Card>();
        card.cardData = (AEffect)argV[0];
        hand.Add(card);
    }
}
