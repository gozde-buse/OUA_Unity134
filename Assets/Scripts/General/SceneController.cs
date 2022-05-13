using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Sahneler arası geçişi kontrol edecek.

    public static SceneController instance { get; private set; }

    [HideInInspector] public string prevScene;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Sahneyi yükleyecek.
    public void LoadScene(string sceneName)
    {
        prevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    //Önceki sahneyi yükleyecek.
    private void LoadPrevScene()
    {
        if(prevScene != "")
        {
            SceneManager.LoadScene(prevScene);
            prevScene = "";
        }
    }
}
