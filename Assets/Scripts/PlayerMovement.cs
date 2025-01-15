using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    Vector2 moveDirection = new Vector2(0.00f, 1.00f);
    float moveSpeed = 2.0f;

    private void OnEnable()
    {
        Actions.MoveEvent += HandleMovement;
    }

    private void OnDisable()
    {
        Actions.MoveEvent -= HandleMovement;
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }



     void HandleMovement(Vector2 moveDirection)
    {
        controller.Move(moveDirection * Time.deltaTime);
    }
}
