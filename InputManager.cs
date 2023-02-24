using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;     

public class InputManager : MonoBehaviour
{
    public PlayerGUI gui;  
    public Gun gun;       
    private PlayerInput playerInput;      
    private PlayerInput.OnFootActions onFoot;   

    private PlayerMotor motor;          
    private PlayerLook look;            
    public PlayerManager PM;            
    public void Update()                 
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            gui.TurnOn();                       
        else if (Input.GetKeyUp(KeyCode.Tab)) 
            gui.TurnOff(); 
    }
    private void Awake()                        
    {                                          
        playerInput = new PlayerInput();        
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx =>motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Walk();

    }
    
    void FixedUpdate()                                      
    {                                                       
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate() =>look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}