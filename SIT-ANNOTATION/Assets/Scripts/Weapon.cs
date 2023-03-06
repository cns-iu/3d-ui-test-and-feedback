using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public float recoil = 1.0f;

    public Transform barrel = null;
    public GameObject projectilePrefab = null;
    
    private XRBaseInteractable interactable = null;
    private Rigidbody rigidBody = null;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        interactable.activated.AddListener(Fire);

    }



    private void OnDisable()
    {
        interactable.activated.RemoveListener(Fire);

    }

    private void Fire(ActivateEventArgs args)
    {
        print("Fire");
        CreateProjectile();
        ApplyRecoil();
    }

    private void CreateProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, barrel.position, barrel.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch();
    }

    public void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.right * recoil, ForceMode.Impulse);
    }

}
