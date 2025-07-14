using UnityEngine;

public class Card
{
    public string Description => data.Description;
    public int Mana { get; private set; }
    private readonly CardData data;

    public Card(CardData cardData)
    {
        data = cardData;
        Mana = cardData.Mana;
    }
}
