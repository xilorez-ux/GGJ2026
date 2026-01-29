using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;


public class MinigameShooterManager : MonoBehaviour
{
    public static bool shootMinigameOn;
    public GameObject cibleTop;//prefab des cibles du haut
    public GameObject cibleMid;//prefab des cibles du milieu
    public GameObject cibleBot;
    private float spawnChrono;//pas touche a ca
    private float spawnSpeed;//vitesse de spawn (a modifié si ont veux plus ou moins de difficulté)
     
    private float chronoRestant = 30f;//durée du minijeux
    private float spawnSpeedHorizontale = 2f; //vitesse de spawn des cibles qui se déplace a l'horizontale
    /// <summary>
    ///point de spawn ci dessous. on a trois étage/marche ou on fait spawn des cibles 
    /// </summary>
    private int randomSpawn; // on va simplement choisir aléatoirement entre la droite et la gauche
  public Transform[] spawnDeGauche; // les spawns a gauche


    void Start()
    {
        //son equipement de l'arme
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInteraction.whatPlayerDo == "PlayingShooter")//nom du minijeux disponible dans le script PlayerInteraction
        {
            MinigameInitialisation(true);
        }
        else
        {
            MinigameInitialisation(false);
        }


    }

    public void MinigameInitialisation(bool initialisation)
    {
        if (initialisation == true)
        {
        for( float i=0; i <= 4; i+= Time.deltaTime)
            {
                //son are you ready ? 
                //phase de préparation ?
                chronoRestant = 30f;
            }
        
        }
        else
        {
            for(float x=0; x<= chronoRestant; chronoRestant -= Time.deltaTime)
            {
            UnityEngine.Debug.Log(chronoRestant);

                //affiché le temp restant
                if(spawnChrono >= spawnSpeed)
                {
                    spawnChrono += Time.deltaTime;

                }
                else
                {
                    //on fait spawn une cible
                    randomSpawn = UnityEngine.Random.Range(0,4);

                    if (randomSpawn == 1)
                    {                                                                                                                   
                        Instantiate(cibleTop);

                    }
                    else if (randomSpawn == 2){
                        Instantiate(cibleMid);
                        
                    }
                    else
                    {
                        Instantiate(cibleBot);
                        

                    }
                    

                    spawnChrono = 0;//on reset le chono de spawn 
                }





            }
           

        }
    }
}
