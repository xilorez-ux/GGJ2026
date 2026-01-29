using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ShotGunArgument : MonoBehaviour
{
    PlayerInput input;
    private int weaponRange=10;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();

    }
    private void Update()
    {
        if (input.inputActions.Player.Attack.IsPressed())
        {
            Debug.Log("je tire ");
            RaycastHit hit;
            Debug.DrawRay(input.transform.position, Camera.main.transform.forward * weaponRange, Color.pink);
            if (Physics.Raycast(input.transform.position, Camera.main.transform.forward, out hit, weaponRange))
            {
                if(hit.rigidbody != null && hit.collider.gameObject.name =="Cible")
                {

                    hit.collider.gameObject.GetComponent<CibleScipt>().ImHit(true);
                }
                    


            }
        }
    }
}
