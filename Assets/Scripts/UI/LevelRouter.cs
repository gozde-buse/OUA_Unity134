using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelRouter : MonoBehaviour
{
    //Leveller arasında geçişi, hangi levellerin kilitli, oyuncunun hangi levelde kaldığını kontrol eden sınıf.

    [SerializeField] private ScrollRect levelRect;
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    private int levelIndex = 0;
    private int sliderLength;
    public int sliderThreshold = 3;

    void Start()
    {
        for(int i = 0; i < Status.level; i++)
        {
            levelButtons[i].interactable = true;
            levelButtons[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            levelButtons[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        sliderLength = levelButtons.Length - sliderThreshold;
    }

    //Tıklanan level açılacak.
    public void LoadLevel(int levelIndex)
    {
        SceneController.LoadScene("Level" + levelIndex.ToString());
    }

    public void Back()
    {
        SceneController.LoadScene("MainMenu");
    }

    public void ScrollPrev()
    {
        if (levelIndex == sliderLength)
            nextButton.interactable = true;

        if (levelIndex != 0)
            levelIndex--;

        if (levelIndex == 0)
            prevButton.interactable = false;

        levelRect.horizontalNormalizedPosition = (float) levelIndex / sliderLength;
    }

    public void ScrollNext()
    {
        if (levelIndex == 0)
            prevButton.interactable = true;

        if (levelIndex != sliderLength)
            levelIndex++;

        if (levelIndex == sliderLength)
            nextButton.interactable = false;

        levelRect.horizontalNormalizedPosition = (float) levelIndex / sliderLength;
    }
}
