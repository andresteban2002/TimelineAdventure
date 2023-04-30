using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class item : MonoBehaviour
{
    public static item instance;
    Pill playerScr;
    private PlayerLife _playerLife;
    private NicknameData data;
    private MatchData matchData;
    [SerializeField] public GameObject[] pillsItem;

    private void Start()
    {
        data = NicknameScript.instance.LoadData();
        matchData = data.matches[NicknameScript.instance.actMatch];
        LoadGame();
        for (var i = 0; i < pillsItem.Length; i++)
        {
            pillsItem[i].SetActive(matchData.collectedItems[i]);
        }
    }

    private void Awake(){
        playerScr = FindObjectOfType<Pill>();
        _playerLife = FindObjectOfType<PlayerLife>();
        instance = this;
    }

    public void SaveGame(){
        Vector2 playerPos = playerScr.GetPosition();
        int pills = playerScr.GetPills();
        matchData.life = PlayerLife.instance.life;
        matchData.cantItems = pills;
        matchData.posX = playerPos.x;
        matchData.posY = playerPos.y;
        data.matches[NicknameScript.instance.actMatch] = matchData;
        string pathData = NicknameScript.instance.GetPathData();
        string nameFileData = NicknameScript.instance.GetFileName();
        
        SaveLoadFileScript.SaveData(data, pathData, nameFileData);
        Debug.Log(JsonUtility.ToJson(data));
    }
    public void LoadGame(){
        Vector2 playerPos = new Vector2(matchData.posX, matchData.posY);
        playerScr.SetPosition(playerPos);
        playerScr.SetPills(matchData.cantItems);
    }
}
