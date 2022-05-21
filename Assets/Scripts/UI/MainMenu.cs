using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Oyuna başlama, oyundan çıkma butonlarının olduğu sayfanın kontrollerini sağlayan sınıf
    [SerializeField] private Text welcomeText;
    [SerializeField] private Text scoreText;

    void Start()
    {
        welcomeText.text = "Hoş geldin, " + Status.userName + ".";
        scoreText.text = "Puan: " + Status.score;
    }

    public void StartGame()
    {
        SceneController.LoadScene("LevelSelection");
    }

    public void GoCards()
    {
        SceneController.LoadScene("ItemList");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
