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

    public override void DrawCard(object[] argV)
    {
        base.DrawCard(argV);

        if ((bool)argV[0]) { return; }
        AEffect effect = cardDeck.deck[cardDeck.deck.Count - 1];
        cardDeck.deck.Remove(effect);
        var arg = new object[] { effect, argV[0] };

        GameEventManager.instance.CallEvent(EventType.OnCardDraw, arg);
    }
}
