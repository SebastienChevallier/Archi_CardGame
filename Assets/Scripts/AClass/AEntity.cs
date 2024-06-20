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
        cardDeck.Start();
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
}
