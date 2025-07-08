using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private HandView handView;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CardView cardView = CardViewCreator.Instance.CreateCardView(transform.position, Quaternion.identity);
            StartCoroutine(handView.AddCard(cardView));
        }
        ;
        
    }
}
