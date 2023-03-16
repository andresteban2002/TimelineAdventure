using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int stones = 0;
    [SerializeField] private Text stonesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stone"))
        {
            Destroy(collision.gameObject);
            stones++;
            stonesText.text = stones.ToString();
        }
    }

    
}
