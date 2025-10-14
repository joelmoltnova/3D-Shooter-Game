using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
    }

    private void FixedUpdate()
    {
        // Handle movement
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        // Enable input
        onFoot.Enable();

        // Subscribe actions
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
    }

    private void OnDisable()
    {
        //  disable
        onFoot.Jump.performed -= ctx => motor.Jump();
        onFoot.Crouch.performed -= ctx => motor.Crouch();
        onFoot.Disable();
    }
}
