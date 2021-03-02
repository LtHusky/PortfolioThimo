using UnityEngine;

public class Shooting : MonoBehaviour
{
    // VARIABLES
    public Transform firePoint;
    public GameObject beamPrefab;
    public float beamForce = 20f;
    public static bool canShoot = true;
    public AudioClip beamShoot;

    // FUNCTIONS
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)   // Shoot on tap & play effect audioclip.
        {
            Shoot();
            AudioSource.PlayClipAtPoint(beamShoot, transform.position);
        }
    }
    
    void Shoot()    // Spawn projectile from player to tap position.
    {
        GameObject Beam = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * beamForce, ForceMode2D.Impulse);
    }
}
