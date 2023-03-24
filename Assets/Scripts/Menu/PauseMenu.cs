using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private Text nickname;
    private bool isPaused;
    // Start is called before the first frame update

    void Start()
    {
        isPaused = false;
        Resume();
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
            Debug.Log(NicknameScript.instance.nameFileData);
            nickname.text = NicknameScript.instance.nameFileData;
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
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
            player.GetComponent<HarryMovement>().canMove = true;
            SceneManager.LoadScene("PrincipalMenu");
        }
    }

}
