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

    public XRRayInteractor xrRayInteractor;
    public float rayDistance = 100f;
    public Color hoverColor = Color.red;

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
    public void Update()
    {
        if (xrRayInteractor.gameObject.CompareTag("Menu Option"))
        {
            xrRayInteractor.hoverEntered.AddListener(OnHoverEnter);
            xrRayInteractor.hoverExited.AddListener(OnHoverExit);
        }
    }

    private void OnDestroy()
    {
        //// Unregister the allowedHoveredActivate event on the XR Ray Interactor.
        ///
        //if (xrRayInteractor != null)
        //{
        //    xrRayInteractor.hoverEntered.RemoveListener(OnHoverEnter);
        //    xrRayInteractor.hoverExited.RemoveListener(OnHoverExit);
        //}

        if (xrRayInteractor != null)
        {
            xrRayInteractor.hoverEntered.RemoveListener(OnHoverEnter);
            xrRayInteractor.hoverExited.RemoveListener(OnHoverExit);
        }
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
    private void OnHoverEnter(HoverEnterEventArgs interactable)
    {
        // Change the color of the material to the hover color.
        material.color = hoverColor;
    }

    private void OnHoverExit(HoverExitEventArgs interactable)
    {
        // Reset the color to the original color.
        material.color = originalColor;
    }


}

