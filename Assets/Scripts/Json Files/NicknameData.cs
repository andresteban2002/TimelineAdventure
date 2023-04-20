using System;
using System.Collections.Generic;

using UnityEngine;


[System.Serializable]
public class NicknameData
{
    public string nickname;
    public List<MatchData> matches;
    public List<AcchievementsData> acchievements;
}
[System.Serializable]
public class MatchData
{
    public string date;
    public int levelAct;
    public int cantItems;
    public float posX;
    public float posY;
    public int life;
    public bool[] collectedItems;
}
[System.Serializable]
public class AcchievementsData
{
    public int level;
    public bool state;
}
