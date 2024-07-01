using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusData", menuName = "Status/DamageOnDraw", order = 1)]
public class DamageOnDraw : Status
{
    public int damageValue;
    
    public override void Use(object[] argV)
    {
        /*foreach (var item in argV)
        {
            Debug.Log(item.GetType());
        }*/
        PlayingEntity enumPlayingEntity = (PlayingEntity)argV[1];
        AEntity origin = (AEntity)argV[2];
        AEntity target = (AEntity)argV[3];

        object[] arg = new object[] { enumPlayingEntity, origin , target };

        if (entityPlaying == enumPlayingEntity)
        {
            if (nbTurnActive < numberOfTurn)
            {                
                target.TakeDamage(damageValue, arg);
                nbTurnActive++;
            }
            else
            {
                GameEventManager.instance.Unsubscribe(EventType.OnCardDraw, Use);
                //DestroyImmediate(this, true);
                origin.CurrentStatus.Remove(this);
            }
        }        
    }
}
