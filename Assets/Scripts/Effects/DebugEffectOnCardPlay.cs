using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusData", menuName = "Status/DebugEffect", order = 1)]
public class DebugEffectOnCardPlay : Status
{    
    public override void Use(object[] argV)
    {
        if(nbTurnActive < numberOfTurn)
        {
            foreach (object arg in argV)
            {
                Debug.Log(arg);
            }
            nbTurnActive++;
        }
        else
        {
            GameEventManager.instance.Unsubscribe(EventType.OnTurnStart, Use);
            DestroyImmediate(this, true);
        }
    }
}
