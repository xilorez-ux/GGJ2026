using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //private PlayerInputController

    [SerializeField]
    private InputSystem_Actions inputActions;
    [SerializeField] private float speed, accel;

    [SerializeField] private Rigidbody rb;

    private Vector2 move;
    private Vector2 playerRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inputActions.Player.Move.performed += Move;
        inputActions.Player.Look.performed += Look; 
    }

    private void Look(InputAction.CallbackContext context)
    {
        playerRotation = context.ReadValue<Vector2>();
        playerRotation.x = 0;
        playerRotation.y = playerRotation.y * (-1);

       
    }

    private void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    [SerializeField] float angleSpeed;

    private void Update()
    {
        rb.linearVelocity = this.transform.right * move.x + this.transform.forward * move.y;


        PlayerYRotation();
        PlayerXRotation();

    }

    private void PlayerYRotation()
    {
        if (playerRotation.y != 0)
        {
            transform.Rotate(transform.up, playerRotation.x * angleSpeed * Time.deltaTime);
            Camera.main.transform.Rotate(Camera.main.transform.right, playerRotation.y * angleSpeed * Time.deltaTime);

            //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            playerRotation = Vector2.zero;

        }

        if (playerRotation.y == 0)
        {
            return;
        }
    }

    private void PlayerXRotation()
    {
        if (playerRotation.x != 0)
        {
            transform.Rotate(transform.forward, playerRotation.y * angleSpeed * Time.deltaTime);
            Camera.main.transform.Rotate(Camera.main.transform.up, playerRotation.x * angleSpeed * Time.deltaTime);

            playerRotation = Vector2.zero;

        }

        if (playerRotation.x == 0)
        {
            return;
        }
    }

}
