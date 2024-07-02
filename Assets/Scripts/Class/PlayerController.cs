using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class PlayerController : AEntity
{
    public GameObject handParent;    

    public override void AddCardToHand(object[] argV)
    {
        if ((PlayingEntity)argV[0] == PlayingEntity.Ennemy) { return; }

        GameObject obj = Instantiate(prefabCard, handParent.transform);
        Card card = obj.GetComponent<Card>();
        card.cardData = (AEffect)argV[3];
        card.Init();
        hand.Add(card);        
    }

    

    public override void DrawCard(object[] argV)
    {
        base.DrawCard(argV);

        if ((PlayingEntity)argV[0] == PlayingEntity.Ennemy) { return; }

        if(hand.Count > 6) { return; }

        if(deck.Count > 0)
        {
            AEffect effect = deck[deck.Count - 1];
            deck.Remove(effect);
            var arg = new object[] { argV[0], argV[1], argV[2], effect };
            GameEventManager.instance.CallEvent(EventType.OnCardDraw, arg);
        }

        if (deck.Count <= 0)
        {
            deck = definitiveDeck.CloneViaSerialization();
            deck.Shuffle();
        }
    }

    public override void TurnStart(object[] argV)
    {
        if ((PlayingEntity)argV[0] == PlayingEntity.Ennemy) return;
        base.TurnStart(argV);        
    }

    
}
