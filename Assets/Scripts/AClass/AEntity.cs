using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AEntity : MonoBehaviour, IHealth
{
    public int currentHealth;
    public int maxHealth;
    public int maxMana;
    public int currentMana;

    [SerializeField] public List<AEffect> deck;
    public List<AEffect> definitiveDeck;//ne pas modifier en runtime
    public List<Card> hand;
    public GameObject prefabCard;

    public List<Status> CurrentStatus;

    public Slider sliderLife;
    public Slider sliderMana;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI manaText;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        deck = definitiveDeck.CloneViaSerialization();
        deck.Shuffle();

        if (sliderLife)
        {
            sliderLife.maxValue = maxHealth;
            sliderLife.value = currentHealth;
            if (lifeText) lifeText.text = currentHealth.ToString();
        }

        if (sliderMana)
        {
            sliderMana.maxValue = maxMana;
            sliderMana.value = currentMana;
            if (manaText) manaText.text = currentMana.ToString();
        }
    }

    protected virtual void Start()
    {        
        GameEventManager.instance.Subscribe(EventType.OnCardDraw, AddCardToHand);
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, DrawCard);
        GameEventManager.instance.Subscribe(EventType.OnTurnStart, TurnStart);  
    }

    public void TakeDamage(int damage, object[] argV)
    {
        currentHealth -= damage;

        if(sliderLife)
        {
            sliderLife.value = currentHealth;
            if (lifeText) lifeText.text = currentHealth.ToString();
        }
        //Debug.Log("Dmg");

        foreach (var item in argV)
        {
            Debug.Log(item.GetType());
        }

        GameEventManager.instance.CallEvent(EventType.OnDamage, argV);
    }

    public void Heal(int damage)
    {
        currentHealth += damage;

        if (sliderLife)
        {
            sliderLife.value = currentHealth;
            if (lifeText) lifeText.text = currentHealth.ToString();
        }           
    }

    public bool UpdateManaValue(int value)
    {
        if (currentMana >= value)
        {
            currentMana -= value;

            if (sliderMana)
            {
                sliderMana.value = currentMana;
                if (manaText) manaText.text = currentMana.ToString();
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
