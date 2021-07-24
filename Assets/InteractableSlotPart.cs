using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSlotPart : Throwable
{
    public InteractableSlot parentSlot;
    public string slotType;
    
    public override void Interact()
    {
        if (parentSlot)
        {
            parentSlot.ReleaseSlot();
            parentSlot = null;
        }
        
        thrown = false;
        StartCoroutine(base.Grab());
    }
    
    public override void StopInteract()
    {
        RaycastHit hit;
        InteractableSlot slot = null;
        Physics.Raycast(camTransform.position, camTransform.forward, out hit);
        if(hit.transform)
            slot = hit.collider.GetComponent<InteractableSlot>();
        if (hit.transform && slot && !slot.slotFilled)
        {
            Vector3 throwDirection = (hit.point - transform.position).normalized;
            throwDirection = throwDirection * throwPower;
            throwDirection.y += throwHeight;
            GetComponent<Rigidbody>().AddForce(throwDirection, ForceMode.VelocityChange);
            
            thrown = true;
            GetComponent<Collider>().enabled = true;
            transform.parent = hit.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            parentSlot = slot; 
            slot.TrySlot(slotType);
            
            slot.slotFilled = true;
        }
        else
        {
            base.StopInteract();
        }
    }
}
