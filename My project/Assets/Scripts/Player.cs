using UnityEngine;

public class Player : MonoBehaviour
{   

    public Rigidbody2D rb;
    AudioSource audio;
    public float speed;
    public int coins =0;

    public int MaxHealth = 3;
    public int Health = 3;

    public bool isDead = false;

    public InfosUIController infosUIController; // Reference to the UI controller
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        infosUIController.UpdateLives(MaxHealth); // Update the UI with the initial health
        infosUIController.UpdateScore(coins); // Update the UI with the initial score
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            coins+=1;
            audio.Play();
            Destroy(other.gameObject);
            infosUIController.UpdateScore(coins); // Update the UI with the new score
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        infosUIController.UpdateLives(Health); // Update the UI with the new health
        if (Health <= 0)
        {
            isDead = true;
            infosUIController.StopTimer(); // Stop the timer when the player dies
            Destroy(gameObject); // Destroy the player object
            
        }

    }
}
