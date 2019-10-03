using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    void Update()
    {
        PickUpBlocks();


    }

    void PickUpBlocks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                Debug.Log("you hit " + hit.transform.name);
                blocks.Add(hit.collider.gameObject);

                Destroy(hit.collider.gameObject);
            }
        }
    }


    void PlaceBlocks()
    {

    }

}
