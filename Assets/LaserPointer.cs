using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : Interactable
{
    public Transform camTransform;
    public LayerMask layerMask;
    public float rotateSpeed = 1;
    public LineRenderer lineRenderer;

    void Start()
    {
    }


    public void TogglePower()
    {
        lineRenderer.enabled = !lineRenderer.enabled;
    }

    public void TogglePower(bool isOn)
    {
        lineRenderer.enabled = isOn;
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            RaycastHit hitFromLaser;
            if (Physics.Raycast(transform.position, hit.point - transform.position, out hitFromLaser, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                var targetRot = Quaternion.LookRotation(hitFromLaser.point - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
                lineRenderer.SetPosition(0, Vector3.up * hitFromLaser.distance);

                Flammable flammable = hitFromLaser.collider.GetComponent<Flammable>();
                if (flammable)
                {
                    flammable.Ignite(hitFromLaser.point);
                }
            }
        }
        else
        {
            var targetRot = Quaternion.LookRotation((camTransform.forward * 10000) - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
            lineRenderer.SetPosition(0, Vector3.up * 1000);

            RaycastHit hitFromLaser;
            if (Physics.Raycast(transform.position, transform.forward, out hitFromLaser, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                lineRenderer.SetPosition(0, Vector3.up * hitFromLaser.distance);
            }
        }
    }

    public override void Interact()
    {
        TogglePower(true);
    }

    public override void StopInteract()
    {
        TogglePower(false);
    }
}