using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class ToggleObject : MonoBehaviour
{
    public static event Action<GameState> OnToggled;

    [SerializeField] private GameObject toggleObject;
    [SerializeField] private InputActionReference joystickButtonClick;

    private bool isObjectEnabled;

    void Start()
    {
        // Set the object to inactive by default
        toggleObject.SetActive(false);
        isObjectEnabled = false;

        // Register the input action event
        if (joystickButtonClick != null)
        {
            joystickButtonClick.action.performed += OnJoystickButtonClick;
        }
    }

    void OnDestroy()
    {
        // Unregister the input action event
        if (joystickButtonClick != null)
        {
            joystickButtonClick.action.performed -= OnJoystickButtonClick;
        }
    }

    private void OnJoystickButtonClick(InputAction.CallbackContext context)
    {
        ToggleObjectVisibility();
    }

    private void ToggleObjectVisibility()
    {
        isObjectEnabled = !isObjectEnabled;
        toggleObject.SetActive(isObjectEnabled);

        if (isObjectEnabled)
        {
            OnToggled?.Invoke(GameState.ShowRadialMenu);
        }
        else
        {
            OnToggled?.Invoke(GameState.DefaultState);
        }
       
    }
}