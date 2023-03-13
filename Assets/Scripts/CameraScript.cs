using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private float playerPosX;
    private float playerPosY;

    private float posX;
    private float posY;

    public float rightMax;
    public float LeftMax;

    public float highMax;
    public float highMin;

    public float cameraSpeed;
    public bool turnOn = true;

    public void Awake()
    {
        posX = playerPosX + LeftMax;
        posY = playerPosX + highMin;
        transform.position = Vector3.Lerp(transform.position, new Vector3( posX, posY, -1), 1);
    }

    void Update()
    {
        if (turnOn)
        {
            if (player)
            {
                playerPosX = player.transform.position.x;
                playerPosY = player.transform.position.y;

                if (playerPosX < rightMax && playerPosX > LeftMax)
                {
                    posX = playerPosX;
                }
                
                if (playerPosY < highMax && playerPosY > highMin)
                {
                    posY = playerPosY;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1),
                cameraSpeed * Time.deltaTime);
        }

    }
}
