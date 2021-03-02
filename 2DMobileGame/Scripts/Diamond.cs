using UnityEngine;

public class Diamond : MonoBehaviour
{
    // VARIABLES
    public GameObject GameOverUI;
    public GameObject highScoreUI;

    // FUNCTIONS
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            Shooting.canShoot = false;
        }
        else
        {
            Time.timeScale = 1f;
            GameOverUI.SetActive(false);
            Shooting.canShoot = true;
        }
    }
}