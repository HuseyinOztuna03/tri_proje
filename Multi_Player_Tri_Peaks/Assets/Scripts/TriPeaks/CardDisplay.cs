using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Threading;

public class CardDisplay : MonoBehaviour
{
    public GameObject p1, p2, p3, p4;
    public GameObject cardPrefab;
    public int numberOfRows;
    public float cardSpacing;
    public int k_bosluk;
    public int bosluk;
    public int yukseklik;
    int lx;
    public static string CurrCard;
    public static int CurrCardid;

    private string[] cardDeck;

    int syc = 0;

    public GameObject[] PCards = new GameObject[23];

    void Start()
    {
        
        lx = k_bosluk + 975;
        
        InitializeCardDeck();
        ShuffleCardDeck();

        string[] copyarr = cardDeck;

        cls(p1);
        crtlinecard(10,1,300,lx,true,p1);
        crtlinecard(23, 0.25f, 100, lx - 525, false,p1);

        cardDeck = copyarr;

        //cls(p1);
        //crtlinecard(10, 1, 300, lx, true, p1);
        //crtlinecard(23, 0.25f, 100, lx - 525, false, p1);

        cardDeck = copyarr;

        //cls(p1);
        //crtlinecard(10, 1, 300, lx, true, p1);
        //crtlinecard(23, 0.25f, 100, lx - 525, false, p1);

        cardDeck = copyarr;

        //cls(p1);
        //crtlinecard(10, 1, 300, lx, true, p1);
        //crtlinecard(23, 0.25f, 100, lx - 525, false, p1);
    }

    public GameObject PcGet(int i)
    {
        return PCards[i];
    }

    public void Pcdel()
    {
        GameObject[] updatedArray = new GameObject[PCards.Length - 1];

        for (int k = 1; k < PCards.Length; k++)
        {
            updatedArray[k - 1] = PCards[k];
        }
        PCards = updatedArray;
    }



    void InitializeCardDeck()
    {
        cardDeck = new string[52];
        int cardIndex = 0;
        string[] suits = { "H", "D", "C", "S" };
        string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "X", "J", "Q", "K" };

        foreach (string suit in suits)
        {
            foreach (string value in values)
            {
                cardDeck[cardIndex] = value + suit;
                cardIndex++;
            }
        }
    }

    void ShuffleCardDeck()
    {
        System.Random random = new System.Random();
        int n = cardDeck.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int r = random.Next(0, i);
            string temp = cardDeck[i];
            cardDeck[i] = cardDeck[r];
            cardDeck[r] = temp;
        }
    }

    void cls(GameObject pl)
    {
        for (int i = 0; i < 3; i++)
        {
            CreatePyramids(this.k_bosluk,pl);
            this.k_bosluk += bosluk;
        }
    }

    void deletearray()
    {
        string[] updatedArray = new string[cardDeck.Length - 1];

        for (int k = 1; k < cardDeck.Length; k++)
        {
            updatedArray[k - 1] = cardDeck[k];
        }
        cardDeck = updatedArray;
    }

    void CreatePyramids(int k_bosluk,GameObject pl)
    {
        for (int i = numberOfRows - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i; j++)
            {
                string cardId = cardDeck[0];
                deletearray();
                Vector3 cardPosition = new Vector3((j * cardSpacing - i * cardSpacing / 2) + k_bosluk, ((numberOfRows - 1 - i) * cardSpacing * (0.75f)) + yukseklik, 0);
                CreateCard(cardId, cardPosition, i, false, pl);
            }
        }
    }

    void crtlinecard(int kac,float c, int yuk, int xxx,bool ýsopen,GameObject pl)
    { 
        for (int i = 0; i < kac;i++)
        {
            string cardId = cardDeck[0];
            deletearray();
            Vector3 cardPosition = new Vector3(( cardSpacing - i * cardSpacing * c) + xxx, yuk, 0);
            CreateCard(cardId, cardPosition, 4,ýsopen,pl);

            if (cardDeck.Length == 1)
            {
                string lastcardId = cardDeck[0];
                Vector3 lastcardPosition = new Vector3(((kac-13) * cardSpacing * c) + xxx, yuk, 0);
                CreateCard(lastcardId, lastcardPosition, 3, true,pl);
                CurrCard = lastcardId;
            }
        }
    }

    void CreateCard(string cardId, Vector3 position,int ordlyr,bool ýsopen, GameObject players)
    {
        GameObject card = Instantiate(cardPrefab, position, Quaternion.identity);
        card.transform.SetParent(players.gameObject.transform);

        Canvas canvas = card.GetComponent<Canvas>();
        

        card.GetComponent<CardData>().isOpen = ýsopen;
        card.name = cardId;
        card.GetComponent<CardData>().cardName = card.name;

        canvas.overrideSorting = true;
        canvas.sortingLayerName = "MySortingLayer";
        canvas.sortingOrder = ordlyr+1;

        if (ordlyr==4 & ýsopen==false)
        {
            PCards[syc] = card;
            syc++;
        }
    }

}