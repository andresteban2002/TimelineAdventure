using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign_Script : MonoBehaviour
{
    [SerializeField] private GameObject signDialog;
    [SerializeField] private GameObject CuriosityPanel;
    private bool stayDialog;

    private void Start()
    {
        stayDialog = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&stayDialog)
        {
            CuriosityPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signDialog.SetActive(true);
            stayDialog = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signDialog.SetActive(true);
            stayDialog = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signDialog.SetActive(false);
            stayDialog = false;
        }
    }
}
