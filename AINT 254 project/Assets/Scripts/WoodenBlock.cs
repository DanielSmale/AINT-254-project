using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBlock : MonoBehaviour
{
    public Rigidbody blockRB;
    public int integrity = 4; // how many times it can be walked over before collapsing

    private void Start()
    {
        blockRB.useGravity = false;
        blockRB.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        integrity = integrity - 1;
    }

    private void FixedUpdate()
    {
        if (integrity == 0)
        {
            blockRB.useGravity = true;
            blockRB.isKinematic = false;
        }
    }
}
