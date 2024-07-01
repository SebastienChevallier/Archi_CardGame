using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;


public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    public Dictionary<EventType, Action<object[]>> events;    

    private void Awake()
    {
        events = new ();
        instance = this;
    }

    public void Subscribe(EventType type, Action<object[]> myFunction)
    {
        if (events.ContainsKey(type))
        {
            events[type] += myFunction;
            Debug.Log("Subscribe : " +  type.ToString());
        }
        else
        {
            events.Add(type, myFunction);
        }
              
    }

    public void Unsubscribe(EventType type, Action<object[]> myFunction) 
    {
        if (events.ContainsKey(type))
        {
            events[type] -= myFunction;
            Debug.Log("Unsubscribe : " + type.ToString());
        }
        
    }

    public void CallEvent(EventType type, object[] argV)
    {
        if (events.ContainsKey(type))
        {
            Debug.Log("Call : " + type.ToString());
            events[type](argV);
        }        
    }
}
