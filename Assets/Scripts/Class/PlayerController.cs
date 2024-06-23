using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AEntity
{
    public GameObject handParent;
    

    public override void AddCardToHand(object[] argV)
    {
        GameObject obj = Instantiate(prefabCard, handParent.transform);
        Card card = obj.GetComponent<Card>();
        card.cardData = (AEffect)argV[0];
        card.Init();
        hand.Add(card);
    }

    public override void DrawCard(object[] argV)
    {
        base.DrawCard(argV);

        if (!(bool)argV[0]) { return; }
        AEffect effect = cardDeck.deck[cardDeck.deck.Count - 1];
        cardDeck.deck.Remove(effect);
        var arg = new object[] { effect, argV[0] };

        GameEventManager.instance.CallEvent(EventType.OnCardDraw, arg);
    }
}
