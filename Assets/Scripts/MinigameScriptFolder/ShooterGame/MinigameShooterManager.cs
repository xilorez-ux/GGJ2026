
using System;
using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;


public class MinigameShooterManager : MonoBehaviour
{
    public static bool shootMinigameOn;
    public GameObject prefabCibleUno;//prefab des cibles tout en haut
    public GameObject prefabCibleDeux;
    public GameObject prefabCibleTrois;
    public GameObject prefabCibleQuatre;



    private float spawnChrono;//pas touche a ca

    private float spawnSpeed = 1;//vitesse de spawn (a modifié si ont veux plus ou moins de difficulté)
     
    public static float chronoRestant;//durée restant du minijeux
    
    private int randomSpawn; // on va simplement choisir aléatoirement entre la droite et la gauche
   // les spawns a gauche

    


    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (chronoRestant >= 0 && PlayerInteraction.instance.whatPlayerDo == playerState.playingShooter)
        {
            chronoRestant -= Time.deltaTime;

            spawnChrono += Time.deltaTime;
            //affiché le temp restant
            if (spawnChrono >= spawnSpeed)
            {
                spawnChrono = 0;
                

                randomSpawn = UnityEngine.Random.Range(1,4);
                Debug.Log(randomSpawn);

                if (randomSpawn == 1)
                {
                    Instantiate(prefabCibleUno, transform.parent);
                    
                }
                else if (randomSpawn == 2)
                {
                    Instantiate(prefabCibleDeux, transform.parent);
                }
                else if (randomSpawn == 3)
                {
                    Instantiate(prefabCibleTrois, transform.parent);
                }
                else
                {
                    Instantiate(prefabCibleQuatre, transform.parent);
                }


                }
           
 

            





        }
    }

}
