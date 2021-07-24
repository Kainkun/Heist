using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContainer : MonoBehaviour
{
    List<InteractableSlot> slots = new List<InteractableSlot>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            InteractableSlot slot = child.GetComponent<InteractableSlot>();
            if (slot)
            {
                slots.Add(slot);
                slot.parentContainer = this;
            }
        }
    }

    public bool CheckAllSlots()
    {
        foreach (InteractableSlot slot in slots)
        {
            if (!(slot.correctObject))
            {
                print("nay");
                return false;
            }
        }
        print("yay");
        return true;
    }
}
