using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Safe : Interactable
{
    public CinemachineVirtualCamera cam;
    public Transform dial;
    private float currentSpin;
    public float maxSpinSpeed = 360;
    private Renderer _renderer;

    private float totalLeftRotation;
    private bool dialBroke;

    [EasyButtons.Button]
    public void CameraFocus()
    {
        cam.Priority = 1000;
        //GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = false;
        GameManager.TogglePlayerInput(false);
    }

    [EasyButtons.Button]
    public void CameraReturn()
    {
        cam.Priority = 0;
        //GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = true;
        GameManager.TogglePlayerInput(true);
    }

    public override void Interact()
    {
        if(dialBroke)
            return;
        
        GameManager.SetActionMap("Safe");
        CameraFocus();
    }

    public override void StopInteract()
    {
        GameManager.SetActionMap("Player");
        CameraReturn();
    }

    public void Spin(float amount)
    {
        currentSpin = amount;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(dialBroke)
            return;
        
        dial.RotateAround(_renderer.bounds.center, -transform.forward, currentSpin * maxSpinSpeed * Time.deltaTime);
        if (currentSpin * maxSpinSpeed * Time.deltaTime < 0)
        {
            totalLeftRotation += currentSpin * maxSpinSpeed * Time.deltaTime;
            if (totalLeftRotation < -360*5)
            {
                dialBroke = true;
                dial.parent = null;
                Rigidbody rb = dial.gameObject.AddComponent<Rigidbody>();
                rb.AddRelativeTorque(new Vector3(0,180,0), ForceMode.VelocityChange);
            }
        }
    }
}
