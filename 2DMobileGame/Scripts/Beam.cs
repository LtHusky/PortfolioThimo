using UnityEngine;

public class Beam : MonoBehaviour
{
    // VARIABLES
    public GameObject hitEffect;
    public static bool enemyDestroyed;
    public AudioClip beamHit;

    // FUNCTIONS
    void Start()
    {   // Ignore collision between Beam & Diamond, Destroy Beam after 2 sec.
        Physics2D.IgnoreLayerCollision(8, 9);
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter2D(Collision2D other)
    {   // Instantiate hitEffect & Destroy Beam  
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);

        if (other.gameObject.tag == "Enemy")  // Destroy Enemy & Give player score.
        {
            AudioSource.PlayClipAtPoint(beamHit, transform.position);
            Destroy(other.gameObject);
            enemyDestroyed = true;
            ScoreManager.score++;
        }
        else
        {
            enemyDestroyed = false;
            Destroy(gameObject, 2);
        }
    }
}