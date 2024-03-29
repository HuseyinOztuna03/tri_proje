using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    CardDisplay sk;
    Transform crt;
    CardData tęklanankart;
    DeckFront deckFront;

    public void Start()
    {
        GameObject deckObject = GameObject.Find("DeckObject");
        deckFront = deckObject.GetComponent<DeckFront>();

        sk = GameObject.Find("GameCanvas").GetComponent<CardDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tęklanankart = GetComponent<CardData>();
        crt = GameObject.Find("P1Handler").transform.Find(CardDisplay.CurrCard);

        if (CardDisplay.CurrCard != tęklanankart.name && tęklanankart.isOpen)
        {
            if ((CardDisplay.CurrCardid == 0 && tęklanankart.cardid == 12) | CardDisplay.CurrCardid == tęklanankart.cardid + 1 | tęklanankart.cardid - 1 == CardDisplay.CurrCardid | (CardDisplay.CurrCardid == 12 && tęklanankart.cardid == 0))
            {    
                tęklanankart.gameObject.transform.position =crt.transform.position;
                crt.gameObject.SetActive(false);
                CardDisplay.CurrCard = tęklanankart.cardName;
                CardDisplay.CurrCardid = tęklanankart.cardid;
                
            }
        }

        if(tęklanankart.isOpen == false & CardDisplay.CurrCard != tęklanankart.name)
        {
            if (sk.PcGet(0).name == tęklanankart.name)
            {
                sk.PcGet(0).transform.position = crt.transform.position;
                crt.gameObject.SetActive(false);
                CardDisplay.CurrCard = tęklanankart.cardName;
                CardDisplay.CurrCardid = tęklanankart.cardid;
                gameObject.GetComponent<Image>().sprite = deckFront.sprites[tęklanankart.konum];

                sk.Pcdel();
            }
        }
    }
}