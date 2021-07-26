using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Throwable : Interactable
{
    private Transform handRoot;
    public float grabSpeed = 5;
    public float throwHeight = 3;
    public float throwPower = 10;
//
    protected Transform camTransform;

    private void Start()
    {
        camTransform = GameManager.Instance.player.GetComponent<FirstPersonController>().CinemachineCameraTarget.transform;
    }

    public override void Interact()
    {
        //thrown = false;
        StartCoroutine(Grab());
    }

    public override void StopInteract()
    {
        transform.parent = null;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit))
        {
            Vector3 throwDirection = (hit.point - transform.position).normalized;
            throwDirection = throwDirection * throwPower;
            throwDirection.y += throwHeight;
            GetComponent<Rigidbody>().AddForce(throwDirection, ForceMode.VelocityChange);
        }
        else
        {
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,throwHeight, throwPower), ForceMode.VelocityChange);
        }

        //thrown = true;
    }

    protected IEnumerator Grab()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        // Vector3 startPos = transform.position;
        // Quaternion startRot = transform.rotation;
        handRoot = GameManager.Instance.player.GetComponent<PlayerInteraction>().handRoot;
        //
        // float t = 0;
        // while (t <= 1)
        // {
        //     transform.position = Vector3.Lerp(startPos, handRoot.position, t);
        //     transform.rotation = Quaternion.Slerp(startRot, handRoot.rotation, t);
        //     t += Time.deltaTime * grabSpeed;
        //     yield return null;
        // }
        transform.position = handRoot.position;//for snapping grab
        transform.rotation = Quaternion.identity;//for snapping grab
        
        transform.parent = handRoot;
        yield return null;
    }
}