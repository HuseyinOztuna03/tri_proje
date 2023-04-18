using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    CardDisplay sk;
    Transform crt;
    CardData t�klanankart;
    DeckFront deckFront;

    public void Start()
    {
        GameObject deckObject = GameObject.Find("DeckObject");
        deckFront = deckObject.GetComponent<DeckFront>();

        sk = GameObject.Find("GameCanvas").GetComponent<CardDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        t�klanankart = GetComponent<CardData>();
        crt = GameObject.Find("P1Handler").transform.Find(CardDisplay.CurrCard);

        if (CardDisplay.CurrCard != t�klanankart.name && t�klanankart.isOpen)
        {
            if ((CardDisplay.CurrCardid == 0 && t�klanankart.cardid == 12) | CardDisplay.CurrCardid == t�klanankart.cardid + 1 | t�klanankart.cardid - 1 == CardDisplay.CurrCardid | (CardDisplay.CurrCardid == 12 && t�klanankart.cardid == 0))
            {    
                t�klanankart.gameObject.transform.position =crt.transform.position;
                crt.gameObject.SetActive(false);
                CardDisplay.CurrCard = t�klanankart.cardName;
                CardDisplay.CurrCardid = t�klanankart.cardid;
                
            }
        }

        if(t�klanankart.isOpen == false & CardDisplay.CurrCard != t�klanankart.name)
        {
            if (sk.PcGet(0).name == t�klanankart.name)
            {
                sk.PcGet(0).transform.position = crt.transform.position;
                crt.gameObject.SetActive(false);
                CardDisplay.CurrCard = t�klanankart.cardName;
                CardDisplay.CurrCardid = t�klanankart.cardid;
                gameObject.GetComponent<Image>().sprite = deckFront.sprites[t�klanankart.konum];

                sk.Pcdel();
            }
        }
    }
}