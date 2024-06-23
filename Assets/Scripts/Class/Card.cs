using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public AEffect cardData;
    public TextMeshProUGUI textCardName;
    public TextMeshProUGUI textCardDescription;
    public TextMeshProUGUI textCardCost;

    public void Init()
    {
        textCardName.text = cardData.name;
        textCardDescription.text = cardData.description;
        textCardCost.text = cardData.cost.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseCard(new object[] { cardData });
    }

    public void UseCard(object[] argV)
    {
        object[] v = new object[2];
        v[0] = cardData;
        v[1] = this.gameObject;
        GameEventManager.instance.CallEvent(EventType.OnCardPlay, v);
    }
}
