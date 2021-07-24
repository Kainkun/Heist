using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSlot : MonoBehaviour
{
    [HideInInspector]
    public SlotContainer parentContainer;
    public bool slotFilled;
    public bool correctObject;
    public string requiredSlotType;

    public void TrySlot(string objectSlotType)
    {
        if (requiredSlotType == objectSlotType)
        {
            correctObject = true;
        }
        else
        {
            correctObject = false;
        }
        parentContainer.CheckAllSlots();
    }

    public void ReleaseSlot()
    {
        correctObject = false;
        slotFilled = false;
        parentContainer.CheckAllSlots();
    }
}