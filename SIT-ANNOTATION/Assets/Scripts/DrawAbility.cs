using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawAbility : MonoBehaviour
{
    public TrailRenderer trailRenderer;
    public XRBaseControllerInteractor interactor;

    [SerializeField]  private InputActionReference _trigger;
    private bool isGripButtonPressed = false;

    private void OnEnable()
    {
        //_trigger.action.performed += EnableDrawing;
    }

    private void OnDestroy()
    {
        //_trigger.action.performed -= EnableDrawing;
    }

    void Start()
    {
        // Add grip button press and release listeners to the interactor
        //interactor.selectEntered.AddListener(OnGripButtonPressed);
        //interactor.selectExited.AddListener(OnGripButtonReleased);

        // Disable the trail renderer initially
        trailRenderer.enabled = false;
    }

    void Update()
    {
        //_trigger.action.IsPressed();
        // Enable the trail renderer while the grip button is pressed
        if ( _trigger.action.IsPressed())
        {
            trailRenderer.enabled = true;
        }
        // Disable the trail renderer while the grip button is released
        else
        {
            trailRenderer.enabled = false;
        }
    }

    void EnableDrawing(InputAction.CallbackContext ctx) {
        isGripButtonPressed = !isGripButtonPressed;
    }

    void OnGripButtonPressed(SelectEnterEventArgs args)
    {
        // Set the grip button pressed flag to true
        isGripButtonPressed = true;
    }

    void OnGripButtonReleased(SelectExitEventArgs args)
    {
        // Set the grip button pressed flag to false
        isGripButtonPressed = false;
    }
}

