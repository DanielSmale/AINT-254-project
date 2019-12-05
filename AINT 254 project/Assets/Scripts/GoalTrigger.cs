using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You win");


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }

}
