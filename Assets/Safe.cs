using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class Safe : Interactable
{
    public CinemachineVirtualCamera cam;
    public Transform dial;
    
    [EasyButtons.Button]
    public void CameraFocus()
    {
        cam.Priority = 100;
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
        CameraFocus();
    }

    public override void StopInteract()
    {
        CameraReturn();
    }
}
