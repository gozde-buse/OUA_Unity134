using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Status
{
    //Oyuncunun durumuyla ilgili genel bilgileri tutan sınıf

    public static string userName { get; private set; }
    public static int score { get; private set; }
    public static int level { get; private set; }
    public static bool[] unlockedCollactables { get; private set; } = new bool[5];

    public static void SetUserName(string userName)
    {
        Status.userName = userName.Trim();
    }

    public static void SetScore(int score)
    {
        Status.score = score;
    }

    public static void SetLevel(int level)
    {
        Status.level = level;
    }

    public static void SetUnlockedCollactables(int index)
    {
        if(!unlockedCollactables[index])
            unlockedCollactables[index] = true;
    }

    public static void SetUnlockedCollactables(int index, bool unlocked)
    {
        unlockedCollactables[index] = unlocked;
    }
}
