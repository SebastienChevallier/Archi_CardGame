using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerController : AEntity
{
    public GameObject handParent;
    

    public override void AddCardToHand(object[] argV)
    {
        if ((PlayingEntity)argV[1] == PlayingEntity.Ennemy) { return; }

        GameObject obj = Instantiate(prefabCard, handParent.transform);
        Card card = obj.GetComponent<Card>();
        card.cardData = (AEffect)argV[0];
        card.Init();
        hand.Add(card);
    }

    public override void DrawCard(object[] argV)
    {
        base.DrawCard(argV);

        if ((PlayingEntity)argV[0] == PlayingEntity.Ennemy) { return; }

        if(cardDeck.deck.Count > 0)
        {
            AEffect effect = cardDeck.deck[cardDeck.deck.Count - 1];
            cardDeck.deck.Remove(effect);
            var arg = new object[] { effect, argV[0], argV[1], argV[2] };
            GameEventManager.instance.CallEvent(EventType.OnCardDraw, arg);
        }
    }

    public override void TurnStart(object[] argV)
    {
        if ((PlayingEntity)argV[0] == PlayingEntity.Ennemy) return;
        base.TurnStart(argV);        
    }
}
