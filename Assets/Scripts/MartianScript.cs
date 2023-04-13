using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartianScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;

    public float distanceToStop = 5f;
    public float topLimit = 55;
    public float bottomLimit = 30;
    public float speed = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (target.transform.position.x > transform.position.x) {
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(x: speed * Time.deltaTime, y:0, z:0);
        } else {
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.Translate(x: speed * Time.deltaTime * -1, y:0, z:0);
        }

        transform.localScale = scale;
    }

    private void FixedUpdate() {
        if (target != null) {
            Debug.Log(transform.position);

            if (transform.position.y > topLimit) {
                rb.velocity = -transform.up * speed;
            } else if (transform.position.y < bottomLimit) {
                rb.velocity = transform.up * speed;
            } else {
                if (Vector2.Distance(target.position, transform.position) < distanceToStop){
                    rb.velocity = transform.up * speed;
                } else if (Vector2.Distance(target.position, transform.position) > distanceToStop){
                    rb.velocity = -transform.up * speed;
                } else {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }

}
