using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 7.0f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get Vector2 of the movement direction using Unity's input system
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection.normalized * playerSpeed; // Add .normalized to make sure player doesnt move faster diagonally
    }
}
