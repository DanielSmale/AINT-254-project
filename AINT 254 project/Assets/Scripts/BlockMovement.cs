using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public GameObject block;
    public Queue<GameObject> blocks = new Queue<GameObject>();
    RaycastHit blockHit;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickUpBlocks();
        }

        if (Input.GetMouseButtonDown(1))
        {
            PlaceBlocks();
        }

    }

    void PickUpBlocks()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out blockHit, 500.0f))
        {


            Destroy(blockHit.collider.gameObject); // Destroy the block from the world and instiatiate a new block ready to be placed

            blocks.Enqueue(block);


        }

    }


    void PlaceBlocks()
    {
        GameObject blockToPlace;

        
        blockToPlace = blocks.Dequeue();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out blockHit, 500.0f))
        {
            blockHit.collider.gameObject.SetActive(true);
            //Generate new block
            Vector3 blockPos = blockHit.point + blockHit.normal / 2.0f;

            blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
            blockPos.y = (float)Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
            blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

            GameObject block = (GameObject)Instantiate(blockToPlace, blockPos, Quaternion.identity);

        }

    }
}
