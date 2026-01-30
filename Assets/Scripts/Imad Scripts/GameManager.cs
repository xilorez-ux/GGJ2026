using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float delayToSwitch = 5f;

    public bool isKawaiiMap = true;
    public bool needToSwitchMaps = true;
    private float distanceBetweenMaps = 59.4f;

    public Action OnChangingLayer;

    [SerializeField] GameObject Player;
    private Vector3 tempPlayerPos;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }
    private void Start()
    {
        StartCoroutine(ChangeMap(delayToSwitch));
    }

    IEnumerator ChangeMap(float duration)
    {
        OnChangingLayer?.Invoke();
        yield return new WaitForSeconds(duration);
        tempPlayerPos = Player.transform.position;
        if(isKawaiiMap == true && needToSwitchMaps == true)
        {
            Player.transform.position = new Vector3(tempPlayerPos.x, -distanceBetweenMaps, tempPlayerPos.z);
            isKawaiiMap = false;
            needToSwitchMaps=false;
            yield break;
        }

        if (!isKawaiiMap && needToSwitchMaps == true)
        {
            Player.transform.position = new Vector3(tempPlayerPos.x, distanceBetweenMaps, tempPlayerPos.z);
            isKawaiiMap = true;
            needToSwitchMaps=false;
            yield break;
        }
    }
}
