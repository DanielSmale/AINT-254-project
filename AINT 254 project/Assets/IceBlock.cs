using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    public Rigidbody blockRB;
    public float meltTime = 120;
    bool nearFire = false; //Adds a multiplier on the melt time making it melt faster if near fire


    private void Start()
    {
        blockRB.useGravity = false;
        blockRB.isKinematic = true;
    }

    private void Update()
    {
        meltTime -= Time.deltaTime;

        if (meltTime <= 0)
        {
            Melt();
        }

        if (nearFire)
        {
            meltTime -= Time.deltaTime * 2;
        }
    }

    private void Melt()
    {
        blockRB.useGravity = true;
        blockRB.isKinematic = false;
    }

}





