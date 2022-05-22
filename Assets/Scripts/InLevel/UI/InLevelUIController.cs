using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLevelUIController : MonoBehaviour
{
    public int minCountToKey = 30;

    [Header("Life UI")]
    [SerializeField] private Image[] hearts;
    //[SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartHalf;
    [SerializeField] private Sprite heartDead;

    [Header("Collactable UI")]
    [SerializeField] private Image collectableImage;
    [SerializeField] private Text collectableCountText;
    [SerializeField] private Slider collectableSlider;
    [SerializeField] private Sprite[] collectableSprites;

    [Header("Key UI")]
    [SerializeField] private GameObject keyImage;
    [SerializeField] private Image keyBgImage;
    [SerializeField] private Sprite keyOnBgSprite;

    private int heartIndex = 4;
    private int collectableCount = 0;

    private enum LifeStatus { Full, Half }
    private LifeStatus lifeStatus = LifeStatus.Full;

    public void Load()
    {
        collectableImage.sprite = collectableSprites[Status.level];
    }

    public void TakeLife()
    {
        if(lifeStatus == LifeStatus.Full)
        {
            hearts[heartIndex].sprite = heartHalf;
            lifeStatus = LifeStatus.Half;
        }
        else
        {
            hearts[heartIndex].sprite = heartDead;
            lifeStatus = LifeStatus.Full;
            heartIndex--;
        }
    }
    public void Collect()
    {
        collectableCount++;

        collectableCountText.text = collectableCount.ToString();
        collectableSlider.value = (float) collectableCount / minCountToKey;

        if (collectableCount == minCountToKey)
            ActivateKey();
    }

    private void ActivateKey()
    {
        //Baþka sýnýflarda da key activate edilecek.

        keyImage.SetActive(true);
        keyBgImage.sprite = keyOnBgSprite;
    }

    //Test için oluþturuldu. Silinecek.
    void Start()
    {
        collectableImage.sprite = collectableSprites[1];
    }

    //Test için oluþturuldu. Silinecek.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TakeLife();

        if (Input.GetMouseButtonDown(1))
            Collect();
    }
}
