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
    OnTurnStart, 
    OnTurnEnd, 
    OnCardDraw, 
    OnCardDestroy,
    OnCardPlay,
    OnDamage
}