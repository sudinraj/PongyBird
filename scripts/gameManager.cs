using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameEnded = false;
    public void endGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            SceneManager.LoadScene("end");
        }
    }

    public void begin()
    {
        SceneManager.LoadScene("main game");
    }
    public void Restart()
    {
        SceneManager.LoadScene("main game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("start");
    }
}
