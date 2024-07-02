using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerController player;
    public Enemy enemy;

    public PlayingEntity actualPlayingEntity;
    public int turnNumber;
    public TextMeshProUGUI turnText;

    private void Start()
    {
        GameEventManager.instance.Subscribe(EventType.OnCardPlay, OnCardUse);
        //Debug.Log("Subscribed");        
        OnTurnBegin();
    }

    public void OnCardUse(object[] argV)
    {
        AEffect effect = (AEffect)argV[0];
        object[] objArg = new object[3];

        if (actualPlayingEntity == PlayingEntity.Player)
        {
            objArg[1] = player;
            objArg[2] = enemy;
            objArg[0] = actualPlayingEntity;
            if(player.UpdateManaValue(effect.cost)) {
                effect.Use(objArg);

                AEntity entity = (AEntity)objArg[1];
                GameObject obj = (GameObject)argV[1];
                if (obj.TryGetComponent<Card>(out Card card))
                {
                    entity.hand.Remove(card);
                    Destroy(obj);
                }
            }
        }
        else
        {
            objArg[1] = enemy;
            objArg[2] = player;
            objArg[0] = actualPlayingEntity;
            if (enemy.UpdateManaValue(effect.cost)) { 
                effect.Use(objArg);

                AEntity entity = (AEntity)objArg[1];
                GameObject obj = (GameObject)argV[1];
                if (obj.TryGetComponent<Card>(out Card card))
                {
                    entity.hand.Remove(card);
                    Destroy(obj);
                }
            }
        }

               
        
    }

    public void OnTurnBegin()
    {
        GameEventManager.instance.CallEvent(EventType.OnTurnStart, new object[] { actualPlayingEntity, player, enemy });
        
        turnNumber++;
        turnText.text = turnNumber.ToString();
        //Debug.Log("CallEventStart");
    }

    public void OnTurnEnd()
    {
        GameEventManager.instance.CallEvent(EventType.OnTurnEnd, new object[] { actualPlayingEntity, player, enemy });

        if(actualPlayingEntity == PlayingEntity.Player)
        {
            actualPlayingEntity = PlayingEntity.Ennemy;
        }
        else
        {
            actualPlayingEntity = PlayingEntity.Player;
        }

        OnTurnBegin();
    }
}

public enum PlayingEntity
{
    Player,
    Ennemy
}
