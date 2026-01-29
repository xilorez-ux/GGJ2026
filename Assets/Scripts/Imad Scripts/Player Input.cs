using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInput : MonoBehaviour
{
    //private PlayerInputController

    [SerializeField]
    private InputSystem_Actions inputActions;
    [SerializeField] private float speed, accel;

    private float yPlayerAngle, xCameraAngle = 0f;
    [SerializeField] private float xRotationSpeed, yRotationSpeed = 1f;



    [SerializeField] private Rigidbody rb;

    private Vector2 move;
    private Vector2 mousePos;
    private Vector2 playerRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Camera.main.transform.LookAt(Vector2.zero);

        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inputActions.Player.Look.performed += Look; 
    }

    private void Look(InputAction.CallbackContext context)
    {
        playerRotation = context.ReadValue<Vector2>();
        playerRotation.y = playerRotation.y * (-1); 
    }

    [SerializeField] float angleSpeed;
    [SerializeField] private float moveSpeed = 1f;

    private void Update()
    {
        move = inputActions.Player.Move.ReadValue<Vector2>();

        rb.MovePosition(transform.position + (this.transform.right * move.x + this.transform.forward * move.y).normalized * moveSpeed * Time.deltaTime);

        PlayerRotation();
    }

    private void PlayerRotation()
    {
        yPlayerAngle += inputActions.Player.Look.ReadValue<Vector2>().x * xRotationSpeed * Time.deltaTime;

        xCameraAngle -= inputActions.Player.Look.ReadValue<Vector2>().y * yRotationSpeed * Time.deltaTime;
        xCameraAngle = Mathf.Clamp(xCameraAngle, -90f, 90f);


        Camera.main.transform.localRotation = Quaternion.Euler(Vector3.right * xCameraAngle);
        this.transform.rotation = Quaternion.Euler(Vector3.up * yPlayerAngle);
    }
}
