using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverColorChange : MonoBehaviour
{
    private XRBaseInteractor interactor;
    private Material originalMaterial;
    private Color hoverColor = Color.red;
    private new Renderer renderer;

    //public HoverColorChange(Renderer renderer)
    //{
    //    this.renderer = renderer;
    //}

    private void Awake()
    {
        interactor = GetComponent<XRBaseInteractor>();
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    private void OnEnable()
    {
        interactor.hoverEntered.AddListener(OnHoverEnter);
        interactor.hoverExited.AddListener(OnHoverExit);
    }

    private void OnDisable()
    {
        interactor.hoverEntered.RemoveListener(OnHoverEnter);
        interactor.hoverExited.RemoveListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs interactor)
    {
        renderer.material.color = hoverColor;
    }

    private void OnHoverExit(HoverExitEventArgs interactor)
    {
        renderer.material = originalMaterial;
    }
}
