using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Object = UnityEngine.Object;

public class NicknameScript : MonoBehaviour
{
    public static NicknameScript instance;
    public const string pathData = "Data/Test";
    public string nameFileData;
    public NicknameData data;
    public int actMatch;

    public NicknameData LoadData()
    {
        var dataFound = SaveLoadFileScript.LoadData<NicknameData>(pathData, nameFileData);
        if (dataFound != null)
        {
            data = dataFound;
            return data;
        }
        else
        {
            return default;
        }
    }

    public void OnButtonTest()
    {
        SaveData(data);
    }

    public void SaveData(NicknameData newdata)
    {
        SaveLoadFileScript.SaveData(newdata, pathData, nameFileData);
    }

    private void Awake()
    {
        instance = this;
    }

    public string GetPathData()
    {
        return pathData;
    }
    
    public string GetFileName()
    {
        return nameFileData;
    }
}