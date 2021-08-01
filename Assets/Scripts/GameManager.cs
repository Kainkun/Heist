using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameObject Player;
    public static Transform PlayerHandRoot;
    public static PlayerInput PlayerInput;
    public static Transform PlayerCamera;

    private void Awake()
    {
        Instance = this;
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerInput = Player.GetComponent<PlayerInput>();
    }

    private void Start()
    {
        
    }

    public static void SetActionMap(string name)
    {
        PlayerInput.SwitchCurrentActionMap(name);
    }

    public static void TogglePlayerInput()
    {
        
    }
    
    public static void TogglePlayerInput(bool isEnabled)
    {
        //player.GetComponent<FirstPersonController>().enabled = false;
    }
}