using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Leveli başlatmaya yönelik ve genel oyun içi kontrollerin olduğu sınıf.
    [SerializeField] private InLevelUIController uIController;

    void Awake()
    {
        uIController.Load(1);
    }                      
}
