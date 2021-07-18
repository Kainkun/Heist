using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform camTransform;
    public LayerMask layerMask;
    public float rotateSpeed = 1;
    public LineRenderer lineRenderer;
    
    void Start()
    {
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, layerMask))
        {
            RaycastHit hitFromLaser;
            if (Physics.Raycast(transform.position, hit.point - transform.position, out hitFromLaser, Mathf.Infinity, layerMask))
            {
                var targetRot = Quaternion.LookRotation(hitFromLaser.point - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
                lineRenderer.SetPosition(0,Vector3.up * hitFromLaser.distance);
            }
        }
        else
        {
            var targetRot = Quaternion.LookRotation((camTransform.forward * 10000) - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
            lineRenderer.SetPosition(0,Vector3.up * 1000);
        }
    }
}