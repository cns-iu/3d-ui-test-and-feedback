using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

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
    public float rayDistance = 100f;
    public Color hoverColor;

    public Material material;
    public Color originalColor;


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
        _xrSimple.activated.AddListener(PrintActivate);
        
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
    }

    public void OnHoverExit(HoverExitEventArgs interactable)
    {
        // Reset the color to the original color.
        material.color = originalColor;
    }

    public void PrintActivate (ActivateEventArgs interactable)
    {
        Debug.Log(interactable.interactorObject.transform.gameObject.name);
        Debug.Log($"I am printed and my name is {gameObject.name}!!");
    }

}

