using UnityEngine;
using UnityEngine.InputSystem;

public enum playerState
{
    idle = 0, playingShooter =1, 
}

public enum playerLocalisation
{
    playground = 0, entry = 1, shooterStand = 2,
}

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    public playerState whatPlayerDo;
    public playerLocalisation wherePlayerAre;
    private InputSystem_Actions inputActions;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
    }

    void Start()
    {
        whatPlayerDo = playerState.playingShooter;
        MinigameShooterManager.chronoRestant = 30;

        whatPlayerDo = playerState.playingShooter;
        wherePlayerAre = playerLocalisation.entry;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EquipementZoneShooter")
        {
            wherePlayerAre = playerLocalisation.shooterStand;
            Debug.Log(wherePlayerAre);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wherePlayerAre = playerLocalisation.playground;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(whatPlayerDo);
        Debug.Log(wherePlayerAre);
        if (wherePlayerAre == playerLocalisation.shooterStand)
            if (inputActions.Player.Interact.IsPressed())
            {
                whatPlayerDo = playerState.playingShooter;
                MinigameShooterManager.chronoRestant = 30;
            }


    }

}
