using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraController : MonoBehaviour
{

    public Transform playerToRotateAround;

    private void Start()
    {
        playerToRotateAround = GetComponentInParent<Transform>();
    }


    void Update()
    {
        if (Input.GetKey("e"))
        {
            Camera.main.transform.RotateAround(playerToRotateAround.position, Vector3.up, 50 * Time.deltaTime);
        }
        else if (Input.GetKey("q"))
        {
            Camera.main.transform.RotateAround(playerToRotateAround.position, Vector3.up, -50 * Time.deltaTime);

        }
    }
}
