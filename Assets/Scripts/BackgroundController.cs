using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BackgroundController : MonoBehaviour
{
    Camera mainCamera;
    // Store the original background color.
    Color originalBackgroundColor;

    private void Awake()
    {
        mainCamera = Camera.main;
        originalBackgroundColor = mainCamera.backgroundColor;
    }

    private void OnEnable()
    {
        // Subscribe to the start and cancel interact events.
        Actions.StartInteractEvent += ChangeBackgroundColor;
        Actions.CancelInteractEvent += ResetBackgroundColor;
    }

    private void OnDisable()
    {
        // Unsubscribe to the start and cancel interact events.
        Actions.StartInteractEvent -= ChangeBackgroundColor;
        Actions.CancelInteractEvent -= ResetBackgroundColor;
    }

    void ChangeBackgroundColor()
    {
        Debug.Log("Space key is pressed, changing background color");
        mainCamera.backgroundColor = Color.grey;
    }

    void ResetBackgroundColor()
    {
        Debug.Log("Space key is released, resetting background color");
        mainCamera.backgroundColor = originalBackgroundColor;
    }
}
