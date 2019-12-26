using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameData gameData = new GameData();
    Dictionary<string, object> data = new Dictionary<string, object>();

    public static SaveManager Instance; 

    public static bool HasInstance
    {
        get
        {
            return SaveManager.Instance != null;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            FileManager.LoadDataFile();
            
            for (int i = 0; i < gameData.data.Count; i++)
            {
                var rawData = gameData.data[i].Split('|');
                data.Add(rawData[0], rawData[1]);
            }

            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log(JsonUtility.ToJson(gameData));
    }

    object GetValue(string itemLabel)
    {
        if (!SaveManager.HasInstance)
        {
            Debug.LogWarning("No SaveManager Instance");
            return null;
        }

        if (SaveManager.Instance.data.ContainsKey(itemLabel))
        {
            return SaveManager.Instance.data[itemLabel];
        }
        else
        {
            return null;
        }
    }

    void UpdateData(string itemLabel, object value)
    {
        if (SaveManager.Instance.data.ContainsKey(itemLabel))
        {
            SaveManager.Instance.data[itemLabel] = value;
        }
        else
        {
            SaveManager.Instance.data.Add(itemLabel, value);
        }

        WriteData();
    }

    void WriteData()
    {
        if (SaveManager.Instance.gameData == null)
        {
            SaveManager.Instance.gameData = new GameData();
        }

        SaveManager.Instance.gameData.data = new List<string>();

        foreach (var item in SaveManager.Instance.data)
        {
            SaveManager.Instance.gameData.data.Add(item.Key + "|" + item.Value);
        }

        FileManager.SaveDataFile();
    }

    public GameData GetGameData()
    {
        if (gameData != null)
        {
            return gameData;
        } else {
            return new GameData();
        }
    }

    public void SetGameData(GameData _gameData)
    {
        gameData = _gameData;
    }

    public static void Save(string itemLabel, object value)
    {
        if (!SaveManager.HasInstance)
        {
            Debug.LogWarning("No SaveManager Instance");
            return;
        }

        SaveManager.Instance.UpdateData(itemLabel, value);
    }

    public static void Save(SavePropertie propertie)
    {
        if (!SaveManager.HasInstance)
        {
            Debug.LogWarning("No SaveManager Instance");
            return;
        }

        SaveManager.Instance.UpdateData(propertie.label, propertie.GetValue());
    }

    public static object Load(string itemLabel)
    {
        return SaveManager.Instance.GetValue(itemLabel);
    }

    public static object Load(SavePropertie propertie)
    {
        var value = SaveManager.Instance.GetValue(propertie.label);
        propertie.SetValue(value);
        return value;
    }
}