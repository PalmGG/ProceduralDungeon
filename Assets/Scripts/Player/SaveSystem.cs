/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData,true));
    }

    public static void Load() 
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        Debug.Log(_saveData);
    }
}*/
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string SaveFileName() => Application.persistentDataPath + "/save.json";

    public static void Save(PlayerStats.PlayerSaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SaveFileName(), json);
        Debug.Log("Saved: " + json);
        Debug.Log(Application.persistentDataPath + "/ save.json");
    }

    public static PlayerStats.PlayerSaveData Load()
    {
        if (!File.Exists(SaveFileName()))
        {
            Debug.LogWarning("Save file not found. Returning default values.");
            return new PlayerStats.PlayerSaveData { health = 100 }; // Default values
        }

        string json = File.ReadAllText(SaveFileName());
        PlayerStats.PlayerSaveData data = JsonUtility.FromJson<PlayerStats.PlayerSaveData>(json);
        Debug.Log("Loaded: " + json);
        return data;
    }
}

