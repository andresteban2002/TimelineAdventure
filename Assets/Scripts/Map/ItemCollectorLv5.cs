using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ItemCollectorLv5 : MonoBehaviour
{
    private int combustibles;
    GameObject playerH;
    [SerializeField] private Text combustiblesText;
    [SerializeField] private Text totalCombustibleText;
    [SerializeField] private string totalCombustible;
    [SerializeField] private CapsuleCollider2D guard;

    private void Start()
    {
        if (totalCombustible != null)
        {
            totalCombustible = "5";
        }
        totalCombustibleText.text = totalCombustible;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("combustible"))
        {
            Destroy(collision.gameObject);
            combustibles++;
            combustiblesText.text = combustibles.ToString();
            if (combustibles == 20)
            {
                playerH = GameObject.FindGameObjectWithTag("Player");
                playerH.transform.position = new Vector3(844,5,1);
            }        
        }
    }

    private void Update()
    {
        if (combustibles == int.Parse(totalCombustible))
        {
            guard.isTrigger = true;
            combustiblesText.color = new Color(193, 153, 0);
            totalCombustibleText.color = new Color(193, 153, 0);
        }
    }

    public Vector2 GetPosition(){
        return transform.position;
    }

    public int GetCombustibles(){
        return combustibles;
    }

    public void SetPosition(Vector2 pos){
        transform.position = pos;
    }
    
    public void SetCombustibles(int cant)
    {
        combustibles = cant;
        combustiblesText.text = combustibles.ToString();
    }
}