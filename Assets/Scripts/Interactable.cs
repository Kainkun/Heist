using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InputType {Toggle, Hold}

    public InputType inputType;
    public abstract void Interact();
    public abstract void StopInteract();
}
