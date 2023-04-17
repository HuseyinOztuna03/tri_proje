using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tıkla : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //GameObject gc = GameObject.Find("GameCanvas");
        //CardDisplay cd = gc.GetComponent<CardDisplay>();
        CardData tıklanankart = GetComponent<CardData>();
        
        if (CardDisplay.CurrCard != tıklanankart.name)
        {
            if (CardDisplay.CurrCardid==tıklanankart.cardid+1 | tıklanankart.cardid-1 ==CardDisplay.CurrCardid)
            {
                Debug.Log("kartalınabilir");
                tıklanankart.transform.position = new Vector3(x, y, z);
            }
            Debug.Log("Kart adı:" +tıklanankart.name);
        }

    }
}
