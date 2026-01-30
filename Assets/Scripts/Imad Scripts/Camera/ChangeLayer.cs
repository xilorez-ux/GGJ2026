using UnityEngine;

public class ChangeLayer : MonoBehaviour
{

    private InputSystem_Actions inputActions;


    [SerializeField] private LayerMask defaultMask; //on default layer
    [SerializeField] private LayerMask goreMask; //on water layer


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Camera.main.cullingMask = defaultMask;
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputActions.Player.Interact.IsPressed()) //REMPLACER PAR CONDITIONS DE SCORE
        {
            Camera.main.cullingMask = goreMask;
        }
    }
}
