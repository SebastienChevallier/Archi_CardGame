using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AEvent
{
    public EventType eventType;
    public UnityEventObj unityEvent;
}

public class UnityEventObj : UnityEvent<Func<object[]>>
{

}

public enum EventType
{
    OnTurnStart=1, 
    OnTurnEnd = 2, 
    OnCardDraw = 4, 
    OnCardDestroy = 8,
    OnCardPlay = 16,
    OnDamage = 32
}