using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private PlayerUpgradeScript playerUpgradeScript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        playerUpgradeScript = gameObject.GetComponent<PlayerUpgradeScript>();
        PlayerUpgradeScript.OnTriggerEvent.AddListener(UpdateSpeed);
        playerSpeed = playerUpgradeScript.playerSpeed;
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get Vector2 of the movement direction using Unity's input system
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection.normalized * playerSpeed; // Add .normalized to make sure player doesnt move faster diagonally
    }

    void UpdateSpeed()
    {
        playerSpeed = playerUpgradeScript.playerSpeed;
    }
}
