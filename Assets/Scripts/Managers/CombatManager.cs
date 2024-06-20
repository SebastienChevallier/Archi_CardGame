using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerController player;
    public Enemy enemy;

    public bool playerTurn;

    private void Start()
    {
        GameEventManager.instance.Subscribe(EventType.OnCardPlay, OnCardUse);
        Debug.Log("Subscribed");
        OnTurnBegin();
    }

    public void OnCardUse(object[] argV)
    {
        AEffect effect = (AEffect)argV[0];
        object[] objArg = new object[2];

        if (playerTurn)
        {
            objArg[0] = player;
            objArg[1] = enemy;
            if(player.currentMana >= effect.cost) { 
                player.currentMana -= effect.cost;
                effect.Use(objArg);
                Destroy((GameObject)argV[1]);
            }
        }
        else
        {
            objArg[0] = enemy;
            objArg[1] = player;
            if (enemy.currentMana >= effect.cost) { 
                enemy.currentMana -= effect.cost;
                effect.Use(objArg);
                Destroy((GameObject)argV[1]);
            }
        } 
    }

    public void OnTurnBegin()
    {
        GameEventManager.instance.CallEvent(EventType.OnTurnStart, new object[] {playerTurn});
        Debug.Log("CallEventStart");
    }

    public void OnTurnEnd()
    {
        GameEventManager.instance.CallEvent(EventType.OnTurnEnd, new object[0]);
    }
}
