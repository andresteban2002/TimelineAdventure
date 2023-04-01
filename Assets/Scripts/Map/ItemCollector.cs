using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int stones;
    [SerializeField] private Text stonesText;
    GameObject playerH;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stone"))
        {
            Destroy(collision.gameObject);
            stones++;
            stonesText.text = stones.ToString();
            if (stones == 20)
            {
                playerH = GameObject.FindGameObjectWithTag("Player");
                playerH.transform.position = new Vector3(844,5,1);
            }
            changeStateItem(collision.gameObject);             
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

    public void changeStateItem(GameObject stone)
    {
        Debug.Log(NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems.Length+" - "+Array.IndexOf(saveSystem.instance.stonesItem, stone));
        NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems[Array.IndexOf(saveSystem.instance.stonesItem, stone)] = false;
        Debug.Log(NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems.Length+" - "+Array.IndexOf(saveSystem.instance.stonesItem, stone));
    }
    
    public void SetStones(int cant)
    {
        stones = cant;
        stonesText.text = stones.ToString();
    }
}