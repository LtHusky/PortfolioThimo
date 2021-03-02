using UnityEngine;

public class Enemy : MonoBehaviour
{
    // VARIABLES
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector2 directionToTarget;

    // FUNCTIONS
    void Start()
    {   // Find target & set speed on spawn.
        target = GameObject.Find("Diamond");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range (1f, 2f);
    }
    
    void Update()
    {   // Keep enemy moving to & looking at target.
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        transform.up = target.transform.position - transform.position;
    }
}