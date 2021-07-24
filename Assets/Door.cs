using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool interactionDone;

    public bool doorOpen;
    public float speed = 90;
    public float openAngle;
    public float closedAngle;
    private float t;
    public AnimationCurve animationCurve;

    private void Update()
    {
        if (doorOpen)
        {
            if(t < 1)
                t += Time.deltaTime * speed;
        }
        else
        {
            if(t > 0)
                t -= Time.deltaTime * speed;
        }

        float angle = Mathf.Lerp(closedAngle, openAngle, animationCurve.Evaluate(t));
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }

    public override void Interact()
    {
        if(interactionDone)
            return;
        
        doorOpen = true;
    }

    public override void StopInteract()
    {
        
    }


}
