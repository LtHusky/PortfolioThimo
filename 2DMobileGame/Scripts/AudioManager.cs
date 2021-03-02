using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // VARIABLES
    public AudioSource beamHit;
    public AudioSource mainMenu;

    // FUNCTIONS
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int scene = currentScene.buildIndex;

        if (Beam.enemyDestroyed == true)
        {
            beamHit.Play();
        }

        if (scene == 1)
        {
            mainMenu.Stop();
        }
    }
}