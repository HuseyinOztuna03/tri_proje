using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CardData : MonoBehaviour
{
    private Image image;
    public bool isOpen;
    public string cardName;
    public int cardid;

    private void Start()
    {
        GameObject deckObject = GameObject.Find("DeckObject");
        DeckFront deckFront = deckObject.GetComponent<DeckFront>();

        image = GetComponent<Image>();

        for (int i = 0; i < deckFront.sprites.Length; i++)
        {
            if (deckFront.sprites[i].name==cardName & isOpen)
            {
                image.sprite = deckFront.sprites[i];
                cardid = i % 13;
            }
            if (deckFront.sprites[i].name==cardName& isOpen==false)
            {
                cardid = i % 13;
            }
        }

    }
}