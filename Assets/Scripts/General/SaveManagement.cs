using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManagement
{
    //Playerprefleri kaydeden metod
    public static void Save()
    {
        string path = Application.persistentDataPath + "/player.data";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Playerprefleri yükleyen metod
    public static void Load()
    {
        string path = Application.persistentDataPath + "/player.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            data.LoadData();
            stream.Close();
        }
    }

    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/player.data";

        if (File.Exists(path))
            File.Delete(path);
    }
}

[Serializable]
public class PlayerData
{
    public string userName;
    public int score;
    public int level;
    public string unlockedCollactables;

    public PlayerData()
    {
        userName = Status.userName;
        score = Status.score;
        level = Status.level;
        unlockedCollactables = "";

        for (int i = 0; i < Status.unlockedCollactables.Length; i++)
            unlockedCollactables += Status.unlockedCollactables[i] ? 1 : 0;

        Debug.Log(unlockedCollactables);
    }

    public void LoadData()
    {
        Status.SetUserName(userName);
        Status.SetScore(score);
        Status.SetLevel(level);

        for (int i = 0; i < Status.unlockedCollactables.Length; i++)
            Status.SetUnlockedCollactables(i, unlockedCollactables[i] == '1' ? true : false);
    }
}

