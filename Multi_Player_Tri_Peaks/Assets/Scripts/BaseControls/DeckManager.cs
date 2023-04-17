//using UnityEngine;
//using System.Collections.Generic;

//public class DeckManager : MonoBehaviour
//{
//    public GameObject cardPrefab;
//    public Transform deckHolder;
//    public DeckFront deck;

//    void Start()
//    {
//        CardData[] cards = deck.GetCards();
//        ShuffleCards(cards);
//        foreach (CardData cardData in cards)
//        {
//            GameObject cardObject = Instantiate(cardPrefab, deckHolder);
//            cardObject.GetComponent<Card>().Initialize(cardData);
//            cardObject.transform.SetParent(deckHolder, false);
//        }
//    }

//    void ShuffleCards(CardData[] cards)
//    {
//        for (int i = 0; i < cards.Length; i++)
//        {
//            int randomIndex = Random.Range(i, cards.Length);
//            CardData temp = cards[randomIndex];
//            cards[randomIndex] = cards[i];
//            cards[i] = temp;
//        }
//    }
//}
