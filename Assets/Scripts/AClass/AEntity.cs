using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEntity : MonoBehaviour, IHealth
{
    public int currentHealth;
    public int maxHealth;
    public int maxMana;
    public int currentMana;

    public Deck cardDeck;
    public List<Card> hand;
    public GameObject prefabCard;


    protected virtual void Start()
    {        
        GameEventManager.instance.Subscribe(EventType.OnCardDraw, AddCardToHand);
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, DrawCard);
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, TurnStart);

        currentHealth = maxHealth;
        currentMana = maxMana;
        Debug.Log("Subscribe deck");
        
    }

    public void TakeDamage(int damage)
    {
        object[] argV = new object[0];
        GameEventManager.instance.CallEvent(EventType.OnDamage, argV);
        Debug.Log("Dmg");
    }

    public virtual void AddCardToHand(object[] argV)
    {
        
    }

    
    public virtual void DrawCard(object[] argV)
    {
        

    }

    public virtual void TurnStart(object[] argV)
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
}
