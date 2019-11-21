using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    Rigidbody blockRB;

    [SerializeField]
    private float meltTime = 10;

    public bool touching;
    bool nearFire = false; //Adds a multiplier on the melt time making it melt faster if near fire


    private void Start()
    {
        blockRB = GetComponent<Rigidbody>();

        touching = false;
        blockRB.useGravity = false;
        blockRB.isKinematic = true;
    }

    private void Update()
    {
        if (touching == true)
        {
            meltTime -= Time.deltaTime;
        }

        if (meltTime <= 0)
        {
            Melt();
        }

        if (nearFire)
        {
            meltTime -= Time.deltaTime * 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        touching = true;


    }

    private void Melt()
    {
        blockRB.useGravity = true;
        blockRB.isKinematic = false;
    }

}





