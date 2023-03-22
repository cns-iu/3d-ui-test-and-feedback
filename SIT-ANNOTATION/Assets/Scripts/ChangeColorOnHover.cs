using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;

public class ChangeColorOnHover : MonoBehaviour
{
    //public XRRayInteractor xrRayInteractor;
    //public Color hoverColor = Color.red;

    //private Image image;
    //private Color originalColor;

    /// <summary>
    /// /Trying for material color Instead
    /// </summary>

   // public XRRayInteractor xrRayInteractor;
    [SerializeField] private XRSimpleInteractable _xrSimple;
    [SerializeField] private InputActionReference activated;
    public float rayDistance = 100f;
    public Color hoverColor;

    public Material material;
    public Color originalColor;

    public static event Action<GameState> OnRadialMenuOpen;
    public static event Action<GameState> OnMotionSicknessReport;


    private void Start()
    {
        //image = GetComponent<Image>();
        //originalColor = image.color;



        //// Register the allowedHoveredActivate event on the XR Ray Interactor.
        //if (xrRayInteractor != null)
        //{
        //    xrRayInteractor.hoverEntered.AddListener(OnHoverEnter);
        //    xrRayInteractor.hoverExited.AddListener(OnHoverExit);
        //}

        ///
        /// trying for material color
        ///

        material = GetComponent<Renderer>().material;
        originalColor = material.color;

        // Register the allowedHoveredActivate event on the XR Ray Interactor.
     

    }
    public void Awake()
    {
        _xrSimple = GetComponent<XRSimpleInteractable>();

        _xrSimple.hoverEntered.AddListener(OnHoverEnter);
        _xrSimple.hoverExited.AddListener(OnHoverExit);
        activated.action.performed += PrintActivate;


        GameManager.OnGameStateChanged += OnStateSetActive;



    }

    void OnStateSetActive(GameState newState)
    {
        gameObject.SetActive(newState == GameState.ShowRadialMenu);
    }


    //private void OnHoverEnter(HoverEnterEventArgs interactable)
    //{
    //    // Change the color of the image to the hover color.
    //    image.color = hoverColor;
    //}

    //private void OnHoverExit(HoverExitEventArgs interactable)
    //{
    //    // Reset the color to the original color.
    //    image.color = originalColor;
    //}
    public void OnHoverEnter(HoverEnterEventArgs interactable)
    {
        // Change the color of the material to the hover color.
        material.color = hoverColor;
        OnRadialMenuOpen?.Invoke(GameState.ShowRadialMenu);
        OnMotionSicknessReport?.Invoke(GameState.ReportMotionSickness);
    }

    public void OnHoverExit(HoverExitEventArgs interactable)
    {
        // Reset the color to the original color.
        material.color = originalColor;
    }

    public void PrintActivate (InputAction.CallbackContext ctx)
    {
        Debug.Log($"I am printed and my name is {gameObject.name}!!");
    }

}

