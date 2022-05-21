using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    //Açılan, toplanan elemanların listesini gösteren sahnenein kontrolleri

    [SerializeField] private ScrollRect cardRect;
    [SerializeField] private GameObject[] cards;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    private int cardIndex = 0;
    private int sliderLength;
    public int sliderThreshold = 3;

    void Start()
    {
        //Açık ve kapalı kartlar listelenecek.
        for(int i = 0; i < cards.Length; i++)
        {
            if(Status.unlockedCollactables[i])
            {
                cards[i].transform.GetChild(0).gameObject.SetActive(true);
                cards[i].transform.GetChild(1).gameObject.SetActive(false);
                cards[i].GetComponent<Button>().interactable = true;
            }
        }

        sliderLength = cards.Length - sliderThreshold;
    }

    //Nesneyi gösteren karta tıklanınca arkası dönecek. 
    public void FlipCard(GameObject card)
    {
        card.GetComponent<Animator>().SetTrigger("Flip");
    }

    public void ScrollPrev()
    {
        if (cardIndex == sliderLength)
            nextButton.interactable = true;

        if (cardIndex != 0)
            cardIndex--;

        if (cardIndex == 0)
            prevButton.interactable = false;

        cardRect.horizontalNormalizedPosition = (float)cardIndex / sliderLength;
    }

    public void ScrollNext()
    {
        if (cardIndex == 0)
            prevButton.interactable = true;

        if (cardIndex != sliderLength)
            cardIndex++;

        if (cardIndex == sliderLength)
            nextButton.interactable = false;

        cardRect.horizontalNormalizedPosition = (float)cardIndex / sliderLength;
    }

    public void Back()
    {
        SceneController.LoadScene("MainMenu");
    }
}
