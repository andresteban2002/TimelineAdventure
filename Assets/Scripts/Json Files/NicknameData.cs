using System;
using System.Collections.Generic;

[System.Serializable]
public class NicknameData
{
    public string nickname;
    public List<MatchData> matches;
}
[System.Serializable]
public class MatchData
{
    public string date;
    public int levelAct;
}
