using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [SerializeField] private InputField userNameField;
    [SerializeField] private Text errorText;

    public void Confirm()
    {
        if(userNameField.text == "")
        {
            errorText.text = "Kullanýcý adý boþ olamaz!";
            errorText.gameObject.SetActive(true);

            return;
        }

        Status.SetUserName(userNameField.text);
        Status.SetLevel(1);
        SaveManagement.Save();
        SceneController.LoadScene("MainMenu");
    }
}
