using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        float movementX;
        float movementY;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            movementX = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            movementX = 1;
        }
        else
        {
            movementX = 0;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            movementY = -1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            movementY = 1;
        }
        else
        {
            movementY = 0;
        }

        movementDirection = new Vector2(movementX, movementY); // Get Vector2 of the movement direction using Unity's input system

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
