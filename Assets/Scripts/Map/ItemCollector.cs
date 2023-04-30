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
    [SerializeField] private Text totalStonesText;
    [SerializeField] private string totalStones;
    [SerializeField] private CapsuleCollider2D guard;
    public AudioSource getItem;

    private void Start()
    {
        if (totalStones != null)
        {
            totalStones = "20";
        }
        totalStonesText.text = totalStones;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stone"))
        {
            Destroy(collision.gameObject);
            stones++;
            stonesText.text = stones.ToString();
            getItem.Play();
            changeStateItem(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("pill"))
        {
            Destroy(collision.gameObject);
            stones++;
            stonesText.text = stones.ToString();
            changeStateItem(collision.gameObject);
        }
    }

    private void Update()
    {
        if (stones == int.Parse(totalStones))
        {
            guard.isTrigger = true;
            stonesText.color = new Color(193, 153, 0);
            totalStonesText.color = new Color(193, 153, 0);
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
        NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].collectedItems[Array.IndexOf(saveSystem.instance.stonesItem, stone)] = false;
    }
    
    public void SetStones(int cant)
    {
        stones = cant;
        stonesText.text = stones.ToString();
    }
}