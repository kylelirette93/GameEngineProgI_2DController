using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Reference to character controller.
    CharacterController controller;

    // Initialize input vector.
    Vector3 inputVector = Vector3.zero;

    // Movement speed of the player.
    [SerializeField] float moveSpeed = 2.0f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Subscribe to the move event.
        Actions.MoveEvent += HandleMovement;
    }

    private void Update()
    {
        // Create a movement vector using the input vector's values.
        Vector3 movement = new Vector3(inputVector.x, inputVector.y, 0);
        // Move the player using the input vector.
        MovePlayer(movement);
    }

    void MovePlayer(Vector2 direction)
    {
        // Move the player constantly, using the character controller.
        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    void HandleMovement(Vector2 inputDirection)
    {
        // Assign direction of input to the input vector.
        inputVector = inputDirection;
    }
}
