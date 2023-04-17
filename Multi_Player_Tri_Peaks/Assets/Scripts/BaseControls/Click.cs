using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    CardDisplay sk;
    Transform crt;
    CardData týklanankart;
    DeckFront deckFront;

    public void Start()
    {
        GameObject deckObject = GameObject.Find("DeckObject");
        deckFront = deckObject.GetComponent<DeckFront>();

        sk = GameObject.Find("GameCanvas").GetComponent<CardDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        týklanankart = GetComponent<CardData>();
        crt = GameObject.Find("P1Handler").transform.Find(CardDisplay.CurrCard);

        if (CardDisplay.CurrCard != týklanankart.name && týklanankart.isOpen)
        {
            if ((CardDisplay.CurrCardid == 0 && týklanankart.cardid == 12) | CardDisplay.CurrCardid == týklanankart.cardid + 1 | týklanankart.cardid - 1 == CardDisplay.CurrCardid | (CardDisplay.CurrCardid == 12 && týklanankart.cardid == 0))
            {    
                týklanankart.gameObject.transform.position =crt.transform.position;
                crt.gameObject.SetActive(false);
                CardDisplay.CurrCard = týklanankart.cardName;
                CardDisplay.CurrCardid = týklanankart.cardid;
                
            }
        }

        if(týklanankart.isOpen == false & CardDisplay.CurrCard != týklanankart.name)
        {
            if (sk.PcGet(0).name == týklanankart.name)
            {
                sk.PcGet(0).transform.position = crt.transform.position;
                crt.gameObject.SetActive(false);
                CardDisplay.CurrCard = týklanankart.cardName;
                CardDisplay.CurrCardid = týklanankart.cardid;
                gameObject.GetComponent<Image>().sprite = deckFront.sprites[týklanankart.konum];

                sk.Pcdel();
            }
        }
    }
}