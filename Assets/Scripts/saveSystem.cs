using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class saveSystem : MonoBehaviour
{
    public static saveSystem instance;
    ItemCollector playerScr;
    private NicknameData data;
    private MatchData matchData;
    public GameObject[] stonesItem;

    private void Start()
    {
        data = NicknameScript.instance.LoadData();
        matchData = data.matches[NicknameScript.instance.actMatch];
        LoadGame();
        for (var i = 0; i < stonesItem.Length; i++)
        {
            stonesItem[i].SetActive(matchData.collectedItems[i]);
            if (!matchData.collectedItems[i])
            {
                playerScr.SetStones(playerScr.GetStones()+1);
            }
        }
    }

    private void Awake(){
        playerScr = FindObjectOfType<ItemCollector>();
        instance = this;
    }

    public void SaveGame(){
        Vector2 playerPos = playerScr.GetPosition();
        int stones = playerScr.GetStones();
        matchData.life = PlayerLife.instance.life;
        matchData.cantItems = stones;
        matchData.posX = playerPos.x;
        matchData.posY = playerPos.y;
        data.matches[NicknameScript.instance.actMatch] = matchData;
        string pathData = NicknameScript.instance.GetPathData();
        string nameFileData = NicknameScript.instance.GetFileName();
        SaveLoadFileScript.SaveData(data, pathData, nameFileData);
    }
    
    public void LoadGame(){
        Vector2 playerPos = new Vector2(matchData.posX, matchData.posY);
        playerScr.SetPosition(playerPos);
    }
}
