using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Threading;

public class CardDisplay : MonoBehaviour
{
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

    void Start()
    {
        lx = k_bosluk + 975;
        
        InitializeCardDeck();
        ShuffleCardDeck();

        cls();
        crtlinecard(10,1,300,lx,true);
        crtlinecard(23, 0.25f, 100, lx - 525, false);
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

    void cls()
    {
        for (int i = 0; i < 3; i++)
        {
            CreatePyramids(this.k_bosluk);
            this.k_bosluk += bosluk;
        }
    }

    void CreatePyramids(int k_bosluk)
    {
        int cardCount = 0;
        for (int i = numberOfRows - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i; j++)
            {
                if (cardCount < cardDeck.Length)
                {
                    string cardId = cardDeck[cardCount];
                    string[] updatedArray = new string[cardDeck.Length - 1];

                    for (int k = 1; k < cardDeck.Length; k++)
                    {
                        updatedArray[k - 1] = cardDeck[k];
                    }
                    cardDeck = updatedArray;

                    Vector3 cardPosition = new Vector3((j * cardSpacing - i * cardSpacing / 2) + k_bosluk, ((numberOfRows - 1 - i) * cardSpacing*(0.75f)) + yukseklik, 0);
                    CreateCard(cardId, cardPosition,i,false);
                    cardCount++;
                }
            }
        }
    }

    void crtlinecard(int kac,float c, int yuk, int xxx,bool ýsopen)
    { 
        for (int i = 0; i < kac;i++)
        {
            string cardId = cardDeck[0];
            string[] updatedArray = new string[cardDeck.Length - 1];
            Array.Copy(cardDeck, 1, updatedArray, 0, cardDeck.Length - 1);
            cardDeck = updatedArray;
            Vector3 cardPosition = new Vector3(( cardSpacing - i * cardSpacing * c) + xxx, yuk, 0);
            CreateCard(cardId, cardPosition, 4,ýsopen);

            if (cardDeck.Length == 1)
            {
                string lastcardId = cardDeck[0];
                Vector3 lastcardPosition = new Vector3(((kac-13) * cardSpacing * c) + xxx, yuk, 0);
                CreateCard(lastcardId, lastcardPosition, 4, true);
                CurrCard = lastcardId;
            }
        }
    }

    void CreateCard(string cardId, Vector3 position,int ordlyr,bool ýsopen)
    {
        GameObject card = Instantiate(cardPrefab, position, Quaternion.identity);
        GameObject.fi
        card.transform.SetParent(transform);

        Canvas canvas = card.GetComponent<Canvas>();
        

        card.GetComponent<CardData>().isOpen = ýsopen;
        card.name = cardId;
        card.GetComponent<CardData>().cardName = card.name;

        canvas.overrideSorting = true;
        canvas.sortingLayerName = "MySortingLayer";
        canvas.sortingOrder = ordlyr+1;
    }
}