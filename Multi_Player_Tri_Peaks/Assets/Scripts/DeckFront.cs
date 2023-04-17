using UnityEngine;

public class DeckFront : MonoBehaviour
{
    public Sprite[] sprites;

    private void Awake()
    {
        if (sprites.Length != 52)
        {
            Debug.LogWarning("CardSprites should contain exactly 52 sprites.");
        }
    }
}