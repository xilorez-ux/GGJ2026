using UnityEngine;


public class MinigameShooterManager : MonoBehaviour
{
    //public static bool shootMinigameOn;
    public static int shooterScore;// score du joueur sur ce minijeu
    public GameObject prefabCibleUno;//prefab des cibles tout en haut
    public GameObject prefabCibleDeux;
    public GameObject prefabCibleTrois;
    public GameObject prefabCibleQuatre;

    public GameObject fusilSurLeStand;//pour changer le visuel
    public GameObject fusilDuJoueur;


    private float spawnChrono;//pas touche a ca

    private float spawnSpeed = 2;//vitesse de spawn (a modifié si ont veux plus ou moins de difficulté)
     
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
            fusilSurLeStand.SetActive(false);//visuel Des fusils (on l'attrape)
            fusilDuJoueur.SetActive(true);
            chronoRestant -= Time.deltaTime;

            spawnChrono += Time.deltaTime;
            //affiché le temp restant
            if (spawnChrono >= spawnSpeed)
            {
                spawnChrono = 0;
                

                randomSpawn = UnityEngine.Random.Range(1,5);
              

                if (randomSpawn == 1)
                {
                    Instantiate(prefabCibleUno);
                    
                }
                else if (randomSpawn == 2)
                {
                    Instantiate(prefabCibleDeux);
                }
                else if (randomSpawn == 3)
                {
                    Instantiate(prefabCibleTrois);
                }
                else if (randomSpawn ==4)
                {
                    Instantiate(prefabCibleQuatre);
                }


                }
           
 

            





        }
        else
        {
            fusilSurLeStand.SetActive(true);//visuel Des fusils (on le repose)
            fusilDuJoueur.SetActive(false);
            PlayerInteraction.instance.whatPlayerDo = playerState.idle;
            
        }
    }

}
