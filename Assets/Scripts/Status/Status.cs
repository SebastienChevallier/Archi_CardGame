using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : AEffect
{
    public int numberOfTurn = 1;
    protected int nbTurnActive = 0;
    public PlayingEntity entityPlaying;
    public override void Use(object[] argV)
    {
        
    }

    public virtual void Bind(EventType type, object[] argV)
    {
        
    }
}
