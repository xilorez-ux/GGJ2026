using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeLayer : MonoBehaviour
{

    private InputSystem_Actions inputActions;


    [SerializeField] private LayerMask defaultMask; //on default layer
    [SerializeField] private LayerMask goreMask; //on water layer

    [SerializeField] private Renderer notGlitchedRenderer;
    [SerializeField] private Renderer glitchedRenderer;

    //Get Referenced Renderers, to be able switch to the desired one
    UnityEngine.Rendering.Universal.UniversalAdditionalCameraData additionalCameraData;


    private bool coroutineStarted = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Camera.main.cullingMask = defaultMask; //For Kawaii and gore (start as kawaii)

        //For Glitch Shader (not glitched on start)
        additionalCameraData = Camera.main.transform.GetComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();
        additionalCameraData.SetRenderer(0);

        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if (inputActions.Player.Interact.IsPressed() && coroutineStarted == false) //REMPLACER PAR CONDITIONS DE SCORE
        {
            StartCoroutine(ShaderCoroutine());//coroutine for the delay, avoid to block the udpate
            
        }
    }

    IEnumerator ShaderCoroutine()
    {
        coroutineStarted = true;
        additionalCameraData.SetRenderer(1); //glitched

        yield return new WaitForSeconds(0.1f);
        Camera.main.cullingMask = goreMask; //layer gore

        yield return new WaitForSeconds(0.3f);
        Camera.main.cullingMask = defaultMask; //layer kawaii

        yield return new WaitForSeconds(0.4f);
        Camera.main.cullingMask = goreMask; //layer gore again


        yield return new WaitForSeconds(1f);
        additionalCameraData.SetRenderer(0); //not glitched

        yield return null;
    }
}
