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

    private Vector2 deltaToReach;


    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

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



            deltaToReach.y = transform.rotation.y + 1 + playerRotation.y;
        //Debug.Log("Delta To Reach = " + deltaToReach);
        //Debug.Log("playerRotation.y = " + playerRotation.y);
        Debug.Log("TransformRotation = " + this.transform.rotation.y);
        if (playerRotation.y != deltaToReach.y)
        {
            
            transform.Rotate(transform.up, playerRotation.x * angleSpeed * Time.deltaTime);
            Camera.main.transform.Rotate(Camera.main.transform.right, playerRotation.y * angleSpeed * Time.deltaTime);  
        }
        
    }

}
