using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{

    public Transform playerTransform;
    
    void Update()
    {
        if (playerTransform.position.y < -1)
        {
            Debug.Log("You died");

            
        }
                



    }
    

}
