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
        if (Input.GetKeyDown("w"))
        {
            rb.velocity = transform.forward * speed;
        }

        if (Input.GetKeyDown("a"))
        {
            rb.velocity = -transform.right * speed;
        }

        if (Input.GetKeyDown("d"))
        {
            rb.velocity = transform.right * speed;
        }

        if (Input.GetKeyDown("s"))
        {
            rb.velocity = -transform.forward * speed;
        }
    }




}
