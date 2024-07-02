using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StatusData", menuName = "Status/HealOnDraw", order = 1)]
public class HealOnDraw : Status
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
