using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Transform camTransform;

    public LayerMask layerMask;

    public float maxDistance = 5;

    public Interactable currentInteractable;

    public Transform handRoot;


    private void Start()
    {
        camTransform = GameManager.PlayerCamera;
    }

    public void OnInteract(InputValue value)
    {
        
        
        if (value.Get<float>() == 1)
        {
            if (!currentInteractable)
            {
                RaycastHit hit;
                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, maxDistance, layerMask))
                {
                    Interactable interactable = hit.transform.GetComponent<Interactable>();
                    if (interactable)
                    {
                        currentInteractable = interactable;
                        if(currentInteractable.inputType == Interactable.InputType.Toggle)
                            currentInteractable.Interact();
                    }
                }
            }
            else if (currentInteractable.inputType == Interactable.InputType.Toggle)
            {
                currentInteractable.StopInteract();
                currentInteractable = null;
            }
        }


        if (currentInteractable && currentInteractable.inputType == Interactable.InputType.Hold)
        {
            if (value.Get<float>() == 1)
            {
                currentInteractable.Interact();
            }
            else if (value.Get<float>() == 0)
            {
                currentInteractable.StopInteract();
            }
        }
    }

    public void OnSpin(InputValue value)
    {
        ((Safe) currentInteractable).Spin(value.Get<float>());
    }
}