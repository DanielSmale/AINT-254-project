using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.velocity = transform.forward * speed;
        }

        if (Input.GetKey("a"))
        {
            rb.velocity = -(transform.right * speed);
        }

        if (Input.GetKey("d"))
        {
            rb.velocity = transform.right * speed;
        }

        if (Input.GetKey("s"))
        {
            rb.velocity = -transform.forward * speed;
        }
    }




}
