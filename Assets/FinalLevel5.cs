using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel5 : MonoBehaviour
{
    public AudioSource fruit;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            fruit.Play();
            MartianScript.is_rage = true;
            SceneManager.LoadScene("Game_Level_5_Final");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (MartianScript.is_rage)
        {
            Destroy(gameObject);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}