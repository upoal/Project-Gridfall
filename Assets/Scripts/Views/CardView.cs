using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{

    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text mana;
    [SerializeField] private GameObject wrapper;

    public Card Card { get; private set; }
    public void Setup(Card card)
    {
        Card = card;
        description.text = card.Description;
        mana.text = card.Mana.ToString();
    }

    void OnMouseEnter()
    {
        wrapper.SetActive(false);
        Vector3 pos = new(transform.position.x, -6, 0);
        CardViewHoverSystem.Instance.Show(Card, pos);
    }

    void OnMouseExit()
    {
        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }

}
