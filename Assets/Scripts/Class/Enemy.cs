using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AEntity
{
    public override void AddCardToHand(object[] argV)
    {
        if ((bool)argV[1]) return;
        
        GameObject obj = Instantiate(prefabCard);
        Card card = obj.GetComponent<Card>();
        obj.SetActive(false);
        card.cardData = (AEffect)argV[0];
        hand.Add(card);

        Debug.Log("AddCard to hand");
    }
}
