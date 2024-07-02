using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CardData", menuName = "Card/ApplyStatusOnEndTurn", order = 1)]
public class ApplyStatusOnEndTurn : AEffect
{
    public Status statusToApply;
    public override void Use(object[] argV)
    {
        if (statusToApply != null)
        {
            Debug.Log("UseStatusCard");
            AEntity targetEntity = (AEntity)argV[1];
            Status status = statusToApply.Clone();
            status.entityPlaying = (PlayingEntity)argV[0];
            targetEntity.CurrentStatus.Add(status);
            GameEventManager.instance.Subscribe(EventType.OnTurnEnd, status.Use);
        }
    }
}
