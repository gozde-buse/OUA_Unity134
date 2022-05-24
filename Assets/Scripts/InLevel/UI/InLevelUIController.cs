using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLevelUIController : MonoBehaviour
{
    public int minCountToKey = 30;
    public int maxLevel = 5;

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
    [SerializeField] private Image keyImage;
    [SerializeField] private Sprite keySprite;

    [Header("End Game UI")]
    [SerializeField] private Image collectableEndImage;
    [SerializeField] private Text collectableEndCountText;
    [SerializeField] private Button nextLevelButton;

    [Header("End Game Gain UI")]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private Image itemImage;
    [SerializeField] private Sprite[] itemSprites;

    private int levelIndex;
    private int heartIndex = 4;
    private int collectableCount = 0;
    private bool itemCollected;

    private enum LifeStatus { Full, Half }
    private LifeStatus lifeStatus = LifeStatus.Full;

    public void Load(int level)
    {
        levelIndex = level;
        collectableImage.sprite = collectableSprites[levelIndex];
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
    public void EndGame()
    {
        collectableEndCountText.text = "x" + collectableCount.ToString() + " toplandý!";
        collectableEndImage.sprite = collectableSprites[levelIndex];

        if(itemCollected)
        {
            itemImage.sprite = itemSprites[levelIndex];
            itemPanel.SetActive(true);
        }

        if(levelIndex == maxLevel)
            nextLevelButton.interactable = false;

        endGamePanel.SetActive(true);
    }

    private void ActivateKey()
    {
        //Baþka sýnýflarda da key activate edilecek.

        keyImage.sprite = keySprite;
    }

    public void GoToLevels()
    {
        SceneController.LoadScene("LevelSelection");
    }

    public void Retry()
    {
        SceneController.LoadScene("Level" + levelIndex.ToString());
    }

    public void NextLevel()
    {
        int nextLevelIndex = levelIndex + 1;
        SceneController.LoadScene("Level" + nextLevelIndex.ToString());
    }

    //Test için oluþturuldu. Silinecek.
    void Start()
    {
        levelIndex = 3;
        collectableImage.sprite = collectableSprites[levelIndex];
    }

    //Test için oluþturuldu. Silinecek.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TakeLife();

        if (Input.GetMouseButtonDown(1))
            Collect();

        /*if (collectableCount == 40)
            itemCollected = true;*/

        if (collectableCount == 50)
            EndGame();
    }
}
