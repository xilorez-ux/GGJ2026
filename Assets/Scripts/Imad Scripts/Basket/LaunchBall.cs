using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LaunchBall : MonoBehaviour
{
    private InputSystem_Actions inputActions;


    [SerializeField] Slider verticalSlider;
    [SerializeField] Slider horizontalSlider; 

    private Rigidbody rb;

    private bool coroutineRunning = false;
    private bool secondCoroutineRunning = false;

    [SerializeField] float sliderVerticalDirection = 0f;
    [SerializeField] float sliderHorizontalDirection;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        inputActions = new InputSystem_Actions();
        inputActions.Enable();

    }

    private void Reset()
    {
        verticalSlider = GetComponent<Slider>();
        horizontalSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        //if (verticalSlider.value <= 0f) {verticalSlider.value += 0.1f;}
        //if (horizontalSlider.value <= 0f) {horizontalSlider.value += 0.1f;}

        //if (verticalSlider.value >= 1f) { verticalSlider.value -= 0.1f;}
        //if (horizontalSlider.value >= 1f) { horizontalSlider.value -= 0.1f;}

        //direction = Quaternion.AngleAxis(90, Vector3.forward) * new Vector2(verticalSlider.value, horizontalSlider.value);

        //if (inputActions.Player.Interact.IsPressed())
        //{

        //    rb.MovePosition(direction * Time.deltaTime);
        //}

        if (inputActions.Player.Interact.IsPressed())
        {

            StartCoroutine(MoveBall());
        }
    }


    IEnumerator MoveBall()
    {

        coroutineRunning = true;
        Debug.Log("IsPressed Déclenché");

        for (int i = 0; i < 80; i++)
        {
            rb.MovePosition(transform.position + (this.transform.forward * (-i) + this.transform.up * i) * Time.deltaTime);
            rb.useGravity = true;
        }


        yield return new WaitForSeconds(0.5f);

        for (int j = 0; j < 20; j++)
        {
            rb.MovePosition(transform.position + this.transform.forward * (-j) * Time.deltaTime);
        }
        //if(secondCoroutineRunning == false)
        //{
        //    StartCoroutine(MoveBallSecondStep());
        //}


        coroutineRunning = false;
        yield return null;

    }

    IEnumerator MoveBallSecondStep()
    {
        for (int j = 0; j < 20; j++)
        {
            rb.MovePosition(transform.position + this.transform.forward * (-j) * Time.deltaTime);
        }

        secondCoroutineRunning = false;
        yield return null;
    }
}
