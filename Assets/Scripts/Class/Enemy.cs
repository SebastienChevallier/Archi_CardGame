using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AEntity
{
    public CombatManager CombatManager;
    public override void AddCardToHand(object[] argV)
    {
        if ((PlayingEntity)argV[1] == PlayingEntity.Player) { return; }

        GameObject obj = Instantiate(prefabCard);
        Card card = obj.GetComponent<Card>();
        obj.SetActive(false);
        card.cardData = (AEffect)argV[0];
        hand.Add(card);

        //Debug.Log("AddCard to hand");
    }

    public override void DrawCard(object[] argV)
    {
        base.DrawCard(argV);

        if ((PlayingEntity)argV[0] == PlayingEntity.Player) { return; }

        if (cardDeck.deck.Count > 0)
        {
            AEffect effect = cardDeck.deck[cardDeck.deck.Count - 1];
            cardDeck.deck.Remove(effect);
            var arg = new object[] { effect, argV[0], argV[2], argV[1] };
            GameEventManager.instance.CallEvent(EventType.OnCardDraw, arg);
        }
    }

    public override void TurnStart(object[] argV)
    {
        if ((PlayingEntity)argV[0] == PlayingEntity.Player) return;
        
        base.TurnStart(argV); 
        if(hand.Count > 0) 
        {
            hand[0].UseCard(argV);
        }
        
        CombatManager.OnTurnEnd();
    }
}
