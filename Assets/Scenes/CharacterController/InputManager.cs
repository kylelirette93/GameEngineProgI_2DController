using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    GameInput gameInput;
    void Start()
    {
        gameInput = new GameInput();

        gameInput.Player.Enable();

        gameInput.Player.SetCallbacks(this);
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Actions.MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        
    }
}

public static class Actions
{
    public static Action<Vector2> MoveEvent;
}
