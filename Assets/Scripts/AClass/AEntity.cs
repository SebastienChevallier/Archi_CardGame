using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AEntity : MonoBehaviour, IHealth
{
    public int currentHealth;
    public int maxHealth;
    public int maxMana;
    public int currentMana;

    public Deck cardDeck;
    public List<Card> hand;
    public GameObject prefabCard;

    public List<Status> CurrentStatus;

    public Slider sliderLife;
    public Slider sliderMana;


    protected virtual void Start()
    {        
        GameEventManager.instance.Subscribe(EventType.OnCardDraw, AddCardToHand);
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, DrawCard);
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, TurnStart);
        

        currentHealth = maxHealth;
        currentMana = maxMana;

        if (sliderLife)
        {
            sliderLife.maxValue = maxHealth;
            sliderLife.value = currentHealth;
        }

        if (sliderMana)
        {
            sliderMana.maxValue = maxMana;
            sliderMana.value = currentMana;
        }
        //Debug.Log("Subscribe deck");
        
    }

    public void TakeDamage(int damage, object[] argV)
    {
        currentHealth -= damage;

        if(sliderLife)
        {
            sliderLife.value = currentHealth;
        }
        //Debug.Log("Dmg");
        
        GameEventManager.instance.CallEvent(EventType.OnDamage, argV);
    }

    public bool UpdateManaValue(int value)
    {
        if (currentMana >= value)
        {
            currentMana -= value;

            if (sliderMana)
            {
                sliderMana.value = currentMana;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void AddCardToHand(object[] argV)
    {
        
    }

    
    public virtual void DrawCard(object[] argV)
    {
        

    }

    public virtual void TurnStart(object[] argV)
    {
        currentMana = maxMana;
        UpdateManaValue(0);
    }

    public virtual void TurnEnd(object[] argV)
    {

    }
}
