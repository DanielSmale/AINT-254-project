using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    //Code referenced: https://www.youtube.com/watch?v=4pvuBl_PQKs&list=PLi-ukGVOag_1Ux4oXpm8CA_UH_VDl5tTV&index=2&t=0s

    public GameObject newBlock;
    public Queue<GameObject> blocks = new Queue<GameObject>();

    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 8;




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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f, layerMask))
        {
            Destroy(hit.collider.gameObject); // Destroy the block from the world and instiatiate a new block ready to be placed
            blocks.Enqueue(Instantiate(newBlock));




        }

    }


    void PlaceBlocks()
    {
        GameObject blockToPlace;


        blockToPlace = blocks.Dequeue();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 00.0f, layerMask) && hit.collider.gameObject.name == "PlaceableArea")
        {
            //Generate new block
            Vector3 blockPos = hit.point;

            blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero); // Round the blocks position to the nearest whole number placing it in a more uniform fashion
            blockPos.y = (float)Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
            blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);


            GameObject block = Instantiate(blockToPlace, blockPos, Quaternion.identity);

        }

    }
}


