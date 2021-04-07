using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Static class used for data file / load
/// </summary>

public static class FileManagement
{
    // File name
    private static readonly string fileName = Application.persistentDataPath + "/data.save";

    // Save data to disk
    public static void SaveData(DataToSave dataToSave)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(fileName);
        binaryFormatter.Serialize(file, dataToSave);
        file.Close();
    }

    // Load data from disk
    public static DataToSave LoadData()
    {
        DataToSave data = new DataToSave();
        if (File.Exists(fileName))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Open);
            data = (DataToSave)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            SaveData(data);
        }
        return data;
    }
}
