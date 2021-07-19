using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Interactable
{
    private Transform handRoot;
    public float grabSpeed = 1;
    public Vector3 throwVector = new Vector3(0, 3, 10);
    private bool thrown;
    public override void Interact()
    {
        thrown = false;
        StartCoroutine(Grab());
    }

    public override void StopInteract()
    {
        transform.parent = null;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddRelativeForce(throwVector, ForceMode.VelocityChange);
        thrown = true;
    }

    IEnumerator Grab()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        handRoot = GameManager.Instance.player.GetComponent<PlayerInteraction>().handRoot;

        float t = 0;
        while (t <= 1)
        {
            transform.position = Vector3.Lerp(startPos, handRoot.position, t);
            transform.rotation = Quaternion.Slerp(startRot, handRoot.rotation, t);
            t += Time.deltaTime * grabSpeed;
            yield return null;
        }

        transform.parent = handRoot;
    }
}
