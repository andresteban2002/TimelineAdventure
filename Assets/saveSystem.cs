using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

// public class saveSystem : MonoBehaviour
// {
//     ItemCollector playerScr;
//     private void Awake(){
//         playerScr = FindObjectOfType<ItemCollector>();
//     }

//     public void SaveGame(){
//         Vector2 playerPos = playerScr.GetPosition();
//         int stones = playerScr.GetStones();

//         PlayerPrefs.SetFloat("posX", playerPos.x);
//         PlayerPrefs.SetFloat("posY", playerPos.y);
//         Debug.Log(">>>>>>>>>>>>>>>" + stones.ToString());
//     }
//     public void LoadGame(){
//         Vector2 playerPos = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));

//         playerScr.SetPosition(playerPos);
//     } 
// }
