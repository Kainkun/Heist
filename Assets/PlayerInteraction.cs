using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Transform camTransform;

    public LayerMask layerMask;

    public float maxDistance = 5;

    private Interactable currentInteractable;

    private void Start()
    {
        camTransform = GetComponent<FirstPersonController>().CinemachineCameraTarget.transform;
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            if (!currentInteractable)
            {
                RaycastHit hit;
                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, maxDistance, layerMask))
                {
                    Interactable interactable = hit.transform.GetComponent<Interactable>();
                    if (interactable)
                    {
                        interactable.Interact();
                        currentInteractable = interactable;
                    }
                }
            }
            else
            {
                currentInteractable.StopInteract();
                currentInteractable = null;
            }
        }
    }
}