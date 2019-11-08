using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //code referenced : https://www.youtube.com/watch?v=VbZ9_C4-Qbo&list=WL&index=13

    bool gameHasEnded = false;

    public GameObject gameOverUI;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;

            gameOverUI.SetActive(true);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
