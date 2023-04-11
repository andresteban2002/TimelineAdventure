using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public Transform target;

    [SerializeField]
    public float rightLimit;
    [SerializeField]
    public float leftLimit;
    [SerializeField]
    public float topLimit;
    [SerializeField]
    public float bottomLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = target.transform.position;

        endPos.y += yOffset;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, FollowSpeed*Time.deltaTime);


        // Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        // transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }
}