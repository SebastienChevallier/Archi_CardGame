using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Deck 
{
    public List<AEffect> deck;

    public void Start()
    {
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, DrawCard);
        Debug.Log("Subscribe deck");
    }

    

    public void DrawCard(object[] argV)
    {    
        AEffect effect = deck[deck.Count-1];
        deck.Remove(effect);
        var arg = new object[] { effect, argV[0] };        

        GameEventManager.instance.CallEvent(EventType.OnCardDraw, arg);
        
    }
}
