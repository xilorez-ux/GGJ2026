using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public static string wherePlayerAre;
    public static string whatPlayerDo;
    private InputSystem_Actions inputActions;
    void Start()
    {
        whatPlayerDo = "Nothing";
        wherePlayerAre = "Entry";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EquipementZoneShooter")
        {
            wherePlayerAre = "ShooterStand";
            Debug.Log(wherePlayerAre);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        wherePlayerAre = "Playground";
    }
    // Update is called once per frame
    void Update()
    {
        if(wherePlayerAre == "ShooterStand")
        {
            if (inputActions.Player.Interact.IsPressed())
            {
                whatPlayerDo = "PlayingShooter";

            }
        }
    }

}
