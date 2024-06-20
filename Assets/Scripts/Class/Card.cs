using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public AEffect cardData;

    public void OnPointerClick(PointerEventData eventData)
    {
        UseCard(new object[] { cardData });
    }

    public void UseCard(object[] argV)
    {
        object[] v = new object[2];
        v[0] = cardData;
        v[1] = this;
        GameEventManager.instance.CallEvent(EventType.OnCardPlay, v);
    }
}
