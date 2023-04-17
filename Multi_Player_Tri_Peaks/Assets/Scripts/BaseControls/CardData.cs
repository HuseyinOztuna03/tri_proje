using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CardData : MonoBehaviour
{
    private Image image;
    public bool isOpen;
    public string cardName;

    private void Start()
    {
        GameObject deckObject = GameObject.Find("DeckObject");
        DeckFront deckFront = deckObject.GetComponent<DeckFront>();

        Debug.Log(deckFront.sprites.Length);
        image = GetComponent<Image>();

        if (isOpen)
        {
            foreach (var i in deckFront.sprites)
            {
                if (i.name == cardName)
                {
                    image.sprite = i;
                }
            }
        }

    }
}