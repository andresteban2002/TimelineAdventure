using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int stones = 0;
    [SerializeField] private Text stonesText;
    [SerializeField] float minX, maxX, minY, maxY;
    [SerializeField] GameObject posXTxt, posYTxt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stone"))
        {
            Destroy(collision.gameObject);
            stones++;
            stonesText.text = stones.ToString();
        }
    }

    public Vector2 GetPosition(){
        return transform.position;
    }

    public int GetStones(){
        return stones;
    }

    public void SetPosition(Vector2 pos){
        transform.position = pos;
    }
}