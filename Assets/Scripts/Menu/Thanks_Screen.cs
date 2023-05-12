using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thanks_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Principal_Menu()
    {
        SceneManager.LoadScene("PrincipalMenu");
    }
    
    public void credits_Screen()
    {
        SceneManager.LoadScene("Credits_Scene");
    }
}
