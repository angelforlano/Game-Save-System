using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class FileManager
{
    const string fileName = "/gameData.gdata";

    public static void SaveDataFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Create);
        bf.Serialize(stream, SaveManager.Instance.GetGameData());
        stream.Close();
    }

    public static GameData LoadDataFile()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Open);
            GameData gameData = bf.Deserialize(stream) as GameData;
            stream.Close();
            SaveManager.Instance.SetGameData(gameData);
            return gameData;
        }
        else
        {
            GameData gameData = new GameData();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Create);
            bf.Serialize(stream, gameData);
            return gameData;
        }
    }

    public static void ResetDataFile()
    {
        GameData gameData = new GameData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Create);
        bf.Serialize(stream, gameData);
    }
}