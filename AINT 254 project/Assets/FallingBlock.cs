using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Rigidbody blockRB;

    private void OnTriggerEnter(Collider other)
    {
        blockRB.useGravity = true;
    }



}
