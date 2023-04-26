using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Pill : MonoBehaviour
{
    private int pills;
    [SerializeField] private Text pillsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pill"))
        {
            Destroy(collision.gameObject);
            pills++;
            pillsText.text = pills.ToString();
            changeStateItem(collision.gameObject);
        }
    }

    public Vector2 GetPosition(){
        return transform.position;
    }

    public int GetPills(){
        return pills;
    }

    public void SetPosition(Vector2 pos){
        transform.position = pos;
    }

    public void changeStateItem(GameObject pill)
    {
        Debug.Log(NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems.Length+" - "+Array.IndexOf(item.instance.pillsItem, pill));
        NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems[Array.IndexOf(item.instance.pillsItem, pill)] = false;
        Debug.Log(NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems.Length+" - "+Array.IndexOf(item.instance.pillsItem, pill));
    }
    
    public void SetPills(int cant)
    {
        pills = cant;
        pillsText.text = pills.ToString();
    }
}