using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialMenu : MonoBehaviour
{
    [SerializeField] private GameObject nicknameField;
    public bool isnew = true;
    private NicknameData data;
    private MatchData matchData;
    private SettingsData settingsData;
    [SerializeField] private Button[] matches;

    private string[] scenes;
    // Start is called before the first frame update

    private void Start()
    {
        scenes = new string[5]{"Game_Level_1","Game_Level_2","Game_Level_3","Game_Level_4","Game_Level_5"};
        data = new NicknameData();
        matchData = new MatchData();
        for (int i = 0; i < 5; i++)
        {
            matches[i].interactable = false;
        }
    }

    public void Jugar()
    {
        matchData.date = DateTime.Now.ToString();
        matchData.levelAct = 1;
        matchData.posX = -5.1f;
        matchData.posY = 7.7f;
        matchData.life = 100;
        matchData.collectedItems = new bool[20] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        data = gameObject.GetComponent<NicknameScript>().LoadData();
        data.matches.Add(matchData);
        gameObject.GetComponent<NicknameScript>().actMatch = data.matches.Count - 1;
        gameObject.GetComponent<NicknameScript>().SaveData(data);
        SceneManager.LoadScene("Game_Level_1");
    }
    
    public void CargarPartida()
    {
        data = gameObject.GetComponent<NicknameScript>().LoadData();
        int cantMatch = data.matches.Count;
        if (cantMatch > 0)
        {
            for (int i = 0; i < cantMatch; i++)
            {
                matches[i].interactable = true;
                matches[i].gameObject.GetComponentInChildren<Text>().text = data.matches[i].date;
            }
        }
    }
    
    public void CargarPartidaIndex(int index)
    {
        data = gameObject.GetComponent<NicknameScript>().LoadData();
        gameObject.GetComponent<NicknameScript>().actMatch = index;
        matchData = data.matches[index];
        SceneManager.LoadScene(scenes[matchData.levelAct-1]);
    }

    public void NickNameRegister()
    {
        nicknameField.SetActive(true);
    }
    
    public void CloseNickNameRegister()
    {
        nicknameField.SetActive(false);
    }
    

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
