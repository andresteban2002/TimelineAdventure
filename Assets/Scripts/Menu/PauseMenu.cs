using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        player.GetComponent<HarryMovement>().canMove = false;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        player.GetComponent<HarryMovement>().canMove = true;
    }
    
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        player.GetComponent<HarryMovement>().canMove = true;
    }
    
    public void Close()
    {
        Debug.Log("Cerrando Juego");
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Application.Quit();
    }

}
