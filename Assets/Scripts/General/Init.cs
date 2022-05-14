using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    //Oyun ilk a��ld���nda gerekli bilgileri y�kleyen s�n�f

    void Start()
    {
        SaveManagement.Load();

        if (Status.userName == null || Status.userName == "")
        {
            SceneController.LoadScene("Register");

            return;
        }

        SceneController.LoadScene("MainMenu");
    }
}
