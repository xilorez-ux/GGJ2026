using UnityEngine;

public class CibleScipt : MonoBehaviour
{
    public float speed; //vitesse des cibles
    public Transform[] waypoints;//les différents point ou la cible doit aller
    private Transform target;
    private int destPoint;
    void Start()
    {
        target = waypoints[0];
        this.transform.position = target.position;//je tp la cible pour être sur qu'elle est au bont endroit dans ma scéne a sont invocation.
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//un translation vers notre prochaine cible

        if(Vector3.Distance(transform.position, target.position) < 0.3f)//on est proche de notre cible donc on peut passer a la suivante.
        {
            destPoint = (destPoint+1) % waypoints.Length;
            target = waypoints[destPoint];
        }

    }
    public void ImHit(bool imhit)
    {
        if(imhit == true)
        {
            Destroy(this.GetComponentInParent<GameObject>());
            


        }
    }
}
