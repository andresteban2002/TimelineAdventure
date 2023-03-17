using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    private bool isPaused;
    // Start is called before the first frame update

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
                isPaused = true;
            }
            else
            {
                Resume();
                isPaused = false;
            }
        }
    }

    public void Pause()
    {
        if (player)
        {
            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);
            player.GetComponent<HarryMovement>().canMove = false;
        }
    }

    public void Resume()
    {
        if (player)
        {
            Time.timeScale = 1f;
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
            player.GetComponent<HarryMovement>().canMove = true;
        }
    }
    
    public void Restart()
    {
        if (player)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
            player.GetComponent<HarryMovement>().canMove = true;
        }
    }
    
    public void Close()
    {
        if (player)
        {
            Debug.Log("Cerrando Juego");
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
            Application.Quit();
        }
    }

}
