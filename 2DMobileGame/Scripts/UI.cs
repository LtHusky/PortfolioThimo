using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // VARIABLES
    private Scene currentScene;

    // FUNCTIONS
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Shooting.canShoot = true;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
