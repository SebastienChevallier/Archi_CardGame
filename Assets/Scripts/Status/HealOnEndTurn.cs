using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StatusData", menuName = "Status/HealOnEndTurn", order = 1)]
public class HealOnEndTurn : Status
{
    public int amountToHeal;
    public override void Use(object[] argV)
    {
        /*foreach (var item in argV)
        {
            Debug.Log(item.GetType());
        }*/
        PlayingEntity enumPlayingEntity = (PlayingEntity)argV[0];
        AEntity origin = (AEntity)argV[1];
        AEntity target = (AEntity)argV[2];

        if (entityPlaying == enumPlayingEntity)
        {
            if (nbTurnActive < numberOfTurn)
            {
                origin.Heal(amountToHeal);
                nbTurnActive++;
            }
            else
            {
                GameEventManager.instance.Unsubscribe(EventType.OnTurnEnd, Use);
                //DestroyImmediate(this, true);
                origin.CurrentStatus.Remove(this);
            }
        }
    }
}
