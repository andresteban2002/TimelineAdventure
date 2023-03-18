using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jugar()
    {
        SceneManager.LoadScene("Game_Level_1");
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
