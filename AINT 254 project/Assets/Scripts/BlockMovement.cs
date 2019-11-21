using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockMovement : MonoBehaviour
{
    //Code referenced: https://www.youtube.com/watch?v=4pvuBl_PQKs&list=PLi-ukGVOag_1Ux4oXpm8CA_UH_VDl5tTV&index=2&t=0s


    public Text numBlocksText;

    public GameObject stone;
    public GameObject wood;
    public GameObject ice;


    Queue<GameObject> currentlyUsingBlocks = new Queue<GameObject>();
    private Queue<GameObject> stoneBlocks = new Queue<GameObject>();
    private Queue<GameObject> woodBlocks = new Queue<GameObject>();
    private Queue<GameObject> iceBlocks = new Queue<GameObject>();


    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 8;


    void Update()
    {
        SetCurrentBlockType();

        numBlocksText.text = currentlyUsingBlocks.Count.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            PickUpBlocks();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentlyUsingBlocks.Count > 0)
            {
                PlaceBlocks();
            }
        }

    }

    void PickUpBlocks()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f, layerMask))
        {
            if (hit.collider.gameObject.tag == "Stone")
            {
                Destroy(hit.collider.gameObject); // Destroy the block from the world and instiatiate a new block ready to be placed
                currentlyUsingBlocks.Enqueue(stone);
            }

            if (hit.collider.gameObject.tag == "Wood")
            {
                Destroy(hit.collider.gameObject); // Destroy the block from the world and instiatiate a new block ready to be placed
                woodBlocks.Enqueue(wood);
            }

            if (hit.collider.gameObject.tag == "Ice")
            {
                Destroy(hit.collider.gameObject); // Destroy the block from the world and instiatiate a new block ready to be placed
                iceBlocks.Enqueue(ice);
            }

        }

    }

    private void SetCurrentBlockType()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentlyUsingBlocks = stoneBlocks;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentlyUsingBlocks = woodBlocks;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentlyUsingBlocks = iceBlocks;
        }
    }

    void PlaceBlocks()
    {
        GameObject blockToPlace;



        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f, layerMask))
        {
            blockToPlace = currentlyUsingBlocks.Dequeue();


            //Generate new block
            Vector3 blockPos = hit.point + hit.normal / 2.0f;

            blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero); // Round the blocks position to the nearest whole number placing it in a more uniform fashion
            blockPos.y = -1;                                                           // But force the blocks y to be -1 as the player has no jump
            blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);


            Instantiate(blockToPlace, blockPos, Quaternion.identity);


        }

    }

}
