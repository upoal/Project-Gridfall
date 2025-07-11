using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardHandController : MonoBehaviour
{
    public GameObject cardPrefab;
    public int numberOfCards = 5;
    public float spreadAngle = 20f; // how much to fan out
    public float radius = 250f;

    private List<GameObject> handCards = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateCardHand();
        }
    }

    public void GenerateCardHand()
    {
        // Clear old hand
        foreach (var card in handCards)
        {
            Destroy(card);
        }
        handCards.Clear();

        float startAngle = -spreadAngle * 0.5f * (numberOfCards - 1);

        for (int i = 0; i < numberOfCards; i++)
        {
            float angle = startAngle + i * spreadAngle;
            float radians = angle * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(Mathf.Sin(radians), Mathf.Cos(radians), 0) * radius;
            Vector3 cardPos = transform.position + offset;

            GameObject card = Instantiate(cardPrefab, transform);
            card.transform.position = cardPos;
            card.transform.rotation = Quaternion.Euler(0, 0, -angle); // tilt the card for curve

            handCards.Add(card);
        }
    }
}
