using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Card/ApplyStatusOnDraw", order = 1)]
public class ApplyStatusOnCardDraw : AEffect
{
    public Status statusToApply;
    public override void Use(object[] argV)
    {
        if (statusToApply != null)
        {
            
            AEntity targetEntity = (AEntity)argV[2];
            Status status = statusToApply.Clone();
            status.entityPlaying = (PlayingEntity)argV[0];
            targetEntity.CurrentStatus.Add(status);
            GameEventManager.instance.Subscribe(EventType.OnCardDraw, status.Use);
        }
    }
}
