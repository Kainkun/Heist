using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickdownDoor : Interactable
{
    private Rigidbody rb;
    private bool interacted;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        rb.isKinematic = false;
        rb.AddRelativeForce(new Vector3(0,0,30), ForceMode.VelocityChange);
        rb.AddRelativeTorque(new Vector3(90,0,0), ForceMode.VelocityChange);
        interacted = true;
    }

    public override void StopInteract()
    {
        
    }
}
