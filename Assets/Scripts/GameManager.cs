using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public static PlayerInput PlayerInput;

    private void Awake()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInput = player.GetComponent<PlayerInput>();
    }

    private void Start()
    {
        
    }

    public static void SetActionMap(string name)
    {
        PlayerInput.SwitchCurrentActionMap(name);
    }
}