using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Directory = System.IO.Directory;
using File = System.IO.File;

public class SaveLoadFileScript : MonoBehaviour
{
    public static void SaveData<T>(T data, string path, string filename)
    {
        string fullPath = Application.dataPath + "/" + path + "/";
        bool chechFolderExist = Directory.Exists(fullPath);
        if (!chechFolderExist)
        {
            Directory.CreateDirectory(fullPath);
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath + filename + ".json", json);
    }

    public static T LoadData<T>(string path, string filename)
    {
        string fullPath = Application.dataPath + "/" + path + "/" + filename + ".json";
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            var obj = JsonUtility.FromJson<T>(textJson);
            return obj;
        } else
        {
            return default;
        }

    }
}
