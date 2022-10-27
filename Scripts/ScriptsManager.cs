using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptsManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
	onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
	look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.jump();
    }

    void FixedUpdate()
    {
        //tells the playermotor to move using our value from the movement action
	motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
	look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
	onFoot.Enable();
    }

    private void OnDisable()
    {
	onFoot.Disable();
    }
}
