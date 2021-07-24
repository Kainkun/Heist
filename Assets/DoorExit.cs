using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    private Door door;
    public Collider backtrackBlocker;

    private void Awake()
    {
        door = GetComponentInChildren<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.doorOpen = false;
            door.interactionDone = true;
            backtrackBlocker.enabled = true;
        }
    }
}
