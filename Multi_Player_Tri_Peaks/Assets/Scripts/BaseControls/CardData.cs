using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System;

public class CardData : MonoBehaviour
{
    private Image image;
    public bool isOpen;
    public string cardName;
    public int cardid;

    public int konum;

    private void Start()
    {
        GameObject deckObject = GameObject.Find("DeckObject");
        DeckFront deckFront = deckObject.GetComponent<DeckFront>();

        image = GetComponent<Image>();

        for (int i = 0; i < deckFront.sprites.Length; i++)
        {
            
            if (deckFront.sprites[i].name == cardName & isOpen)
            {
                
                image.sprite = deckFront.sprites[i];
                konum = i;
                cardid = i % 13;
                if (CardDisplay.CurrCard == cardName)
                {
                    CardDisplay.CurrCardid = cardid;
                }
            }
            if (deckFront.sprites[i].name == cardName & isOpen == false)
            {
                konum = i;
                //ön.sprite = deckFront.sprites[i];
                //image.sprite = deckFront.sprites[i];
                cardid = i % 13;
            }
        }

    }
}