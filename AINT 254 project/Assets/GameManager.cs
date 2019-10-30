using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //code referenced : https://www.youtube.com/watch?v=VbZ9_C4-Qbo&list=WL&index=13

    bool gameHasEnded = false;

    public float restartDelay = 10f;


    public void EndGame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
