using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class TownData
{
    public bool hasCollectedTreasure = false;
    public bool spawnMonsters = true;
}

public class PlayerData
{
    public int health;
    public int treasure = 0;
}

public static class SaveLoadManager
{
    public static PlayerData LoadPlayerData(string path)
    {
        if (File.Exists(path))
        {
            Stream stream = File.Open(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            PlayerData loadedData = (PlayerData)serializer.Deserialize(stream);
            stream.Close();
            return loadedData;
        }
        return null;
    }

    public static void SavePlayerData(PlayerData playerData, string path)
    {
        Directory.CreateDirectory("SaveData");
        Stream stream = File.Open(path, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        serializer.Serialize(stream, playerData);
        stream.Close();
    }

    public static TownData LoadTownData(string path)
    {
        if (File.Exists(path))
        {
            Stream stream = File.Open(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(TownData));
            TownData loadedData = (TownData)serializer.Deserialize(stream);
            stream.Close();
            return loadedData;
        }
        return null;
    }

    public static void SaveTownData(TownData townData, string path)
    {
        Directory.CreateDirectory("SaveData/TownData");
        Stream stream = File.Open(path, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(TownData));
        serializer.Serialize(stream, townData);
        stream.Close();
    }

    public static void DeleteExistingData()
    {
        Directory.Delete("SaveData", true);
    }
}

