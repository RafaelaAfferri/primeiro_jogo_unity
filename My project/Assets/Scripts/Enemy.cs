using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player; // Reference to the Player script



    public Transform target;
    public float speed = 3f;

    private Rigidbody2D rb;

    private float damageCooldown = 1f; // Tempo entre os danos
    private float lastDamageTime = -10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                player.TakeDamage(1);
                lastDamageTime = Time.time;
            }
        }
    }

}
