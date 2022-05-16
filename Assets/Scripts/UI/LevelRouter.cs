using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelRouter : MonoBehaviour
{
    //Leveller arasında geçişi, hangi levellerin kilitli, oyuncunun hangi levelde kaldığını kontrol eden sınıf.

    [SerializeField] private Button[] levelButtons;

    void Start()
    {
        //Kilitli olanlar vs görsel olarak gelecek.
    }

    //Tıklanan level açılacak.
    public void LoadLevel(int levelIndex)
    {
        SceneController.LoadScene("Level" + levelIndex.ToString());
    }

    public void Back()
    {
        SceneController.LoadPrevScene();
    }
}
