using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Oyuna başlama, oyundan çıkma butonlarının olduğu sayfanın kontrollerini sağlayan sınıf

    //void Start() {}

    public void StartGame()
    {
        SceneController.instance.LoadScene("LevelSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
