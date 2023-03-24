using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    [SerializeField] private GameObject nicknameField;
    public bool isnew = true;
    private NicknameData data;
    private MatchData matchData;
    // Start is called before the first frame update

    private void Start()
    {
        data = new NicknameData();
        matchData = new MatchData();
    }

    public void Jugar()
    {
        matchData.date = DateTime.Now.ToString();
        matchData.levelAct = 1;
        data = gameObject.GetComponent<NicknameScript>().LoadData();
        data.matches.Add(matchData);
        gameObject.GetComponent<NicknameScript>().SaveData(data);
        SceneManager.LoadScene("Game_Level_1");
    }
    
    public void CargarPartida()
    {
        isnew = false;
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
