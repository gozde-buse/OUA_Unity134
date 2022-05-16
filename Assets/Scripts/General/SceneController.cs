using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    //Sahneler arası geçişi kontrol edecek.

    public static string prevScene;

    //Sahneyi yükleyecek.
    public static void LoadScene(string sceneName)
    {
        prevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    //Önceki sahneyi yükleyecek.
    public static void LoadPrevScene()
    {
        if (prevScene != "")
        {
            SceneManager.LoadScene(prevScene);
            prevScene = "";
        }
    }
}
