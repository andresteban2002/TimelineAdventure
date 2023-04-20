using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private int levelNumber;
    private NicknameData data;
    private string[] scenes;
    // Start is called before the first frame update
    void Start()
    {
        scenes = new string[6]{"Game_Level_1","Game_Level_2","Game_Level_3","Game_Level_4","Game_Level_5", "PrincipalMenu"};
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            complete();
        }
    }
    
    public void complete()
    {
        Time.timeScale = 0f;
        level.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        data = NicknameScript.instance.LoadData();
        data.acchievements[levelNumber - 1].state = true;
        NicknameScript.instance.SaveData(data);
        level.SetActive(false);
        SceneManager.LoadScene(scenes[levelNumber]);
    }
}
    