using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LaunchBall : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Rigidbody rb;

    private bool coroutineRunning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    private void Update()
    {
        if (inputActions.Player.Interact.IsPressed() && coroutineRunning == false)
        {
            StartCoroutine(MoveBall());
        }
    }


    IEnumerator MoveBall() {
           
  
        coroutineRunning = true;
        Debug.Log("IsPressed Déclenché");

        for (int i = 0; i < 90; i++)
        {
            rb.MovePosition(transform.position + (this.transform.forward * (-i) + this.transform.up * i) * Time.deltaTime);
            rb.useGravity = true;
        }

        for (int j = 0; j < 20; j++)
        {
            rb.MovePosition(transform.position + this.transform.forward * (-j) * Time.deltaTime);
        }

        coroutineRunning = false;
        yield return null;
        
    }
}
