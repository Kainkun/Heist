using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private PlayerInteraction _playerInteraction;
    public LaserPointer laserPointer;
    private void Start()
    {
        _playerInteraction = GetComponent<PlayerInteraction>();
    }
    
    
    public void OnFInventory(InputValue value)
    {
        if (_playerInteraction.currentInteractable != laserPointer)
        {
            laserPointer.gameObject.SetActive(true);
            _playerInteraction.currentInteractable = laserPointer;
        }
        else
        {
            _playerInteraction.currentInteractable = null;
            laserPointer.gameObject.SetActive(false);
        }
    }
}
