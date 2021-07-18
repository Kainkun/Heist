using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Safe : Interactable
{
    public CinemachineVirtualCamera cam;
    public Transform dial;
    private float currentSpin;
    public float maxSpinSpeed = 360;
    private Renderer _renderer;

    [EasyButtons.Button]
    public void CameraFocus()
    {
        cam.Priority = 1000;
        GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = false;
    }

    [EasyButtons.Button]
    public void CameraReturn()
    {
        cam.Priority = 0;
        GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = true;
    }

    public override void Interact()
    {
        GameManager.SetActionMap("Safe");
        CameraFocus();
    }

    public override void StopInteract()
    {
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
        dial.RotateAround(_renderer.bounds.center, -transform.forward, currentSpin * maxSpinSpeed * Time.deltaTime);
    }
}
