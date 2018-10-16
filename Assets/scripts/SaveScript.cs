﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(GameData))]
public class SaveScript : MonoBehaviour
{

    private GameData gameData;
    private string savePath;

    void Start()
    {
        gameData = GetComponent<GameData>();
        savePath = Application.persistentDataPath + "/gamesave.save";
    }

    public void SaveData()
    {
        var save = new Save()
        {
            SavedInteger = gameData.GameInteger,
            SavedString = gameData.GameString
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open)) 
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            gameData.GameInteger = save.SavedInteger;
            gameData.GameString = save.SavedString;
            gameData.ShowData();

            Debug.Log("Data Loaded");
        }
        else
        {
            Debug.LogWarning("Save file doesn't exist.");
        }
    }
}