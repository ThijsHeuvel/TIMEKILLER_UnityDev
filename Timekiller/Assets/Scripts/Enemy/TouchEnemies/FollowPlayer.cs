using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 1.5f;

    private Rigidbody2D rb; // Reference to Rigidbody2D
    private Vector2 movement; // Movement direction

    void Start()
    {
        // Find the player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null) // Check if the player exists
        {
            // Calculate the direction to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Store the direction for use in FixedUpdate
            movement = direction;
        }
    }

    void FixedUpdate()
    {
        // Move the enemy towards the player
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
