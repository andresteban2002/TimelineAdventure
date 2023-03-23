using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject finalizar;

    public bool iscomplete = false;

    // Start is called before the first frame update
    void Start()
    {
        iscomplete = false;
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
        Time.timeScale = 0f;
        level.SetActive(false);
    }
}
    