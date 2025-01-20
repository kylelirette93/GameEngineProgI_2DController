using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Reference to character controller.
    Rigidbody2D rb2D;

    // Initialize input vector.
    Vector2 moveVector;

    // Movement speed of the player.
    [SerializeField] float moveSpeed = 2.0f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

        // Subscribe to the move event.
        Actions.MoveEvent += GetInputVector;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Move the player using rigidbody position and velocity scaled.
        rb2D.MovePosition(rb2D.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    void GetInputVector(Vector2 inputDirection)
    {
        // Assign direction of input to the input vector.
        moveVector = inputDirection;
    }
}
