using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    //Oyun ilk açýldýðýnda gerekli bilgileri yükleyen sýnýf

    void Start()
    {
        SaveManagement.Load();

        if (Status.userName == null || Status.userName == "")
        {
            SceneController.LoadScene("Register");

            return;
        }
    }
}
