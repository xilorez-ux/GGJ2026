using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ShotGunArgument : MonoBehaviour
{
    PlayerInput input;
    public GameObject player;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private int weaponPower=1000;
    private bool fireReload=true;

    private void Awake()
    {
        input = player.GetComponent<PlayerInput>();
        
    }

    private void Update()
    {
        if (input.inputActions.Player.Attack.IsPressed()&& fireReload == true)
        {
            StartCoroutine(Fire());
            fireReload = false;
        }
    }
    IEnumerator Fire()
    {
        

            GameObject bulleto = Instantiate(bullet, bulletSpawnPoint.position, Camera.main.transform.rotation);
            bulleto.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * weaponPower);
            yield return new WaitForSeconds(0.5f);
            Destroy(bulleto);
            fireReload = true;
            
        
        
    }
}
