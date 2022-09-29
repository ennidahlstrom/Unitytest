using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private Rigidbody2D batRigidbody;
    private Vector2 direction;
    public int speed;

    // Start is called before the first frame update
    void Start() 
    {
        batRigidbody = GetComponent<Rigidbody2D>();
        direction = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //batRigidbody.AddForce(direction, ForceMode2D.Force);
        batRigidbody.velocity = direction;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
